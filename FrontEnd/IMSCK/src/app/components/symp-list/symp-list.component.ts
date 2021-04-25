import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Symptom } from 'src/app/models/symptom';
import { SymptomsService } from 'src/app/services/symptoms.service';

@Component({
  selector: 'app-symp-list',
  templateUrl: './symp-list.component.html',
  styleUrls: ['./symp-list.component.scss']
})
export class SympListComponent implements OnInit {
  sympList: Symptom[] = [];
  symptomsForm: FormGroup = new FormGroup({});

  constructor(
    private sympService: SymptomsService,
    private formBuilder: FormBuilder,
    private router: Router
    ) { }

  
  ngOnInit(): void {
    this.symptomsForm = this.formBuilder.group({
      checkArray: this.formBuilder.array([])
    })
    this.getSymptoms();
  }


  getSymptoms(): void {
    this.sympService.getSymptoms().subscribe(list => {
      this.sympList = list.data;
    })
  }

  onCheckboxChange(event: any) {
    const checkArray: FormArray = this.symptomsForm.get('checkArray') as FormArray;
  
    if (event.target?.checked) {
      checkArray.push(new FormControl(event.target.value));
    } else {
      let i: number = 0;
      checkArray.controls.forEach(item => {
        if (item.value == event.target.value) {
          checkArray.removeAt(i);
          return;
        }
        i++;
      });
    }
  }

  submitForm() {
    this.sympService.setSelectedSymptoms(this.symptomsForm.getRawValue());
    this.router.navigate(['homepage/questionnaire']);
  }
}