
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
          :rules="[v => !!v || 'Vehicle type is required']"
          label="vehicle type"
          required
        ></v-select>

        <v-btn type="submit" block class="mt-2" color="success">Calculate</v-btn>
      </v-form>
    </v-sheet>
  </div>
</template>

<script>
export default {
  
  data() {
    return {
      vehicleBasePrice: '',
      vehicleBasePriceRules: [
        value => {
            if(value) {
              return true;
            } else {
              return 'Field required';
            }
          }
      ],
      vehicleType: null,
      vehicleTypes: ['Common', 'Luxury'],

    };
  },
  methods: {
    calculatePrice() {

      // axios.post('https://api.example.com/todos', {
      //   title: this.title,
      //   description: this.description,
      //   priority: this.priority,
      // })
      // .then(response => {
      //   console.log('Elemento creado con éxito:', response.data);
      //   // Puedes emitir un evento para notificar a otros componentes sobre la creación
      // })
      // .catch(error => {
      //   console.error('Error al crear el elemento:', error);
      // });
      console.log(this.vehicleBasePrice);
      console.log(this.vehicleType);
    },
  },
};
</script>

<style scoped>
  .form {
    margin-top: 40px;
  }
</style>