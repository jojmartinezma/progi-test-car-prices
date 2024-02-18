import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { VehicleResponse } from './models/vehicleResponse';
import { VehicleServiceService } from './services/vehicle-service.service';
import { VehicleRequest } from './models/vehicleRequest';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{

  public vehicleFeesForm!: FormGroup;
  public vehicleTypeList: Array<string> = ['Common', 'Luxury'];
  public resultApi: boolean = false;
  public vehicleResponse!: VehicleResponse;

  constructor(private _vehicleService: VehicleServiceService) {
  }

  ngOnInit(): void {
    this.initFormGroup();

    // subscribe to form changes
    this.vehicleFeesForm.statusChanges.subscribe((status) => {
      if(status === 'VALID') {
        this.processForm();
      } else {
        this.resultApi = false;
      }
    })
  }

  private initFormGroup() {
    this.vehicleFeesForm = new FormGroup({
      vehicleBasePrice: new FormControl('', [ Validators.required, Validators.pattern(/^\d+$/)]),
      vehicleType: new FormControl(null,[ Validators.required ])
    })
  }

  public processForm() {
    if(this.vehicleFeesForm.valid === false) {
      return;
    }

    // call api
    const vehicleRequest: VehicleRequest = new VehicleRequest({
      vehicleBasePrice: this.vehicleFeesForm.controls['vehicleBasePrice'].value,
      vehicleType: this.vehicleFeesForm.controls['vehicleType'].value,
    });

    this._vehicleService.calculatePrice(vehicleRequest).subscribe({
      next: (res) => {
        if(!res) {
          this.resultApi = false;
        }
        
        // set values
        this.vehicleResponse = res as VehicleResponse;
        this.resultApi = true;
      },
      error: () => {
        this.resultApi = false;
      }
    })

  }
}
