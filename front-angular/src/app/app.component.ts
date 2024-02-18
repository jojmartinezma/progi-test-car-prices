import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';

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

  constructor() {

  }

  ngOnInit(): void {
    this.initFormGroup();
  }

  private initFormGroup() {
    this.vehicleFeesForm = new FormGroup({
      vehicleBasePrice: new FormControl('', [ Validators.required, Validators.pattern(/^\d+$/)]),
      vehicleType: new FormControl(null,[ Validators.required ])
    })
  }

  public processForm() {

  }
}
