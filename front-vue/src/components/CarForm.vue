
<template>
  <div class="form">
    <v-sheet width="300" class="mx-auto">
      <v-form fast-fail @submit.prevent="calculatePrice">
        <v-text-field
          v-model="vehicleBasePrice"
          label="Vehicle base price"
          :rules="vehicleBasePriceRules"
        ></v-text-field>

        <v-select
          v-model="vehicleType"
          :items="vehicleTypes"
          :rules="vehicleTypesRules"
          label="vehicle type"
          required
        ></v-select>

        <v-btn type="submit" :disabled="!isFormComplete" block class="mt-2" color="success">Calculate</v-btn>
      </v-form>

      <!-- api results -->
      <div class="resultApi" v-if="apiResults.status">
        <v-card
          class="mx-auto"
          width="300"
          prepend-icon="mdi-home"
          variant="tonal"
        >
          <template v-slot:title>
            Results, costs and fees
          </template>

          <v-card-text>
            <b>Basic: </b> {{ apiResults.basic }} <br/>
            <b>Special: </b> {{ apiResults.special }} <br/>
            <b>Association: </b> {{ apiResults.asosiation }} <br/>
            <b>Storage: </b> {{ apiResults.storage }} <br/> <br/>
            <div class="total">
              <b>Total: </b> <span class="total-value">{{ apiResults.total }} <br/></span>
            </div>
          </v-card-text>
        </v-card>
    </div>

    </v-sheet>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  
  data() {
    return {
      vehicleBasePrice: '',
      vehicleBasePriceRules: [
        value => {
            if(value && (/^\d+$/.test(value))) {
              return true;
            } else {
              return 'Field required or input incorrect';
            }
          }
      ],
      vehicleType: null,
      vehicleTypes: ['Common', 'Luxury'],
      vehicleTypesRules: [
        value => {
          if(value){
            return true;
          } else {
            return 'Vehicle type is required';
          }
        },
      ],
      apiResults: {
        status: false,
        basic: '',
        special: '',
        asosiation: '',
        storage: '',
        total: '',
      },
    };
  },
  computed: {
    isFormComplete() {
      // validate if all form fields are completed
      if(this.vehicleBasePrice && this.vehicleType) {
        this.calculatePrice();
        return true;
      } else {
        return false;
      }
    },
  },
  methods: {
    calculatePrice() {

      // call api
      if(this.vehicleType && this.vehicleBasePrice) {
        axios.post('https://localhost:7065/api/RatesCalculation', {
          vehicleBasePrice: this.vehicleBasePrice,
          vehicleType: this.vehicleType,
        })
        .then(response => {
          if(response && response.status === 200) {
            this.setApiResults(response.data);
          } else {
            this.resetApiResults();
          }
        })
        .catch(error => {
          console.error('Error sendind the data:', error);
          this.resetApiResults();
        });
      } else {
        this.apiResults.status = false;
      }
    },

    setApiResults(response) {
      this.apiResults.basic = response.basic;
      this.apiResults.special = response.special;
      this.apiResults.asosiation = response.asosiation;
      this.apiResults.storage = response.storage;
      this.apiResults.total = response.total;
      this.apiResults.status = true;
    },

    resetApiResults() {
      this.apiResults.basic = '';
      this.apiResults.special = '';
      this.apiResults.asosiation = '';
      this.apiResults.storage = '';
      this.apiResults.total = '';
      this.apiResults.status = false;
    },
  }
};
</script>

<style scoped>
  .form {
    margin-top: 40px;
  }

  .resultApi {
    margin-top: 40px;
  }

  .total {
    margin-left: 10%;
    font-size: 26px;
  }

  .total-value {
    color: red;
    font-weight: bold;
  }
</style>