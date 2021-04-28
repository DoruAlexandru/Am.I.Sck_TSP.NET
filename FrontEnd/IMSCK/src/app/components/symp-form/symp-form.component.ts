import { FormGroup, FormControl } from '@angular/forms';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Symptom } from 'src/app/models/symptom';

@Component({
  selector: 'app-symp-form',
  templateUrl: './symp-form.component.html',
  styleUrls: ['./symp-form.component.scss'],
})
export class SympFormComponent implements OnInit {
  @Input() symptomsList: Symptom[] = [];
  @Output() submitForm:EventEmitter<unknown> = new EventEmitter();

  symptomsForm: FormGroup = new FormGroup({});

  constructor() {}

  ngOnInit(): void {
    this.generateFormControls();
  }

  generateFormControls(): void {
    this.symptomsList.forEach(item => {
      item.formControlName = `symp_${item.name}`;
      this.symptomsForm.addControl(item.formControlName, new FormControl(''));
    })
  }

  checkSymptoms(formValues: any): void {
    this.submitForm.emit(formValues);
  }
}
