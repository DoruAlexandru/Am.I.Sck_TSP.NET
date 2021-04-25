import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Item } from 'src/app/models/item';
import { Symptom } from 'src/app/models/symptom';
import { SymptomsService } from 'src/app/services/symptoms.service';

@Component({
  selector: 'app-questionnaire',
  templateUrl: './questionnaire.component.html',
  styleUrls: ['./questionnaire.component.scss'],
})
export class QuestionnaireComponent implements OnInit {
  constructor(private router:Router, private sympService: SymptomsService) {}

  show = false;

  symptoms: Symptom[] = [
    {
      name: 'Fever',
      description: 'desc dfgdfgdfgd',
      severities: [
        {
          name: 'Low',
          value: 'Low',
        },
        {
          name: 'Medium',
          value: 'Medium',
        },
        {
          name: 'High',
          value: 'High',
        },
        {
          name: 'Very high',
          value: 'Very high',
        }
      ]
    },
    {
      name: 'Pain',
      description: 'desc hhhhh',
      severities: [
        {
          name: 'Low',
          value: 'Low',
        },
        {
          name: 'Medium',
          value: 'Medium',
        },
        {
          name: 'High',
          value: 'High',
        },
        {
          name: 'Very high',
          value: 'Very high',
        }
      ]
    },
    {
      name: 'Headache',
      description: 'desc  hhhhfdhdfhdhdfh',
      severities: [
        {
          name: 'Low',
          value: 'Low',
        },
        {
          name: 'Medium',
          value: 'Medium',
        },
        {
          name: 'High',
          value: 'High',
        },
        {
          name: 'Very high',
          value: 'Very high',
        }
      ]
    }
  ];


  ngOnInit(): void {
    this.sympService.getSelectedSymptoms().subscribe(res => {
    })
  }

  showQuestionnaire(): void {
    this.show = true;
  }

  getSubmitedSymptoms(event: any): void {
  }

  public listSymptoms(): void {
    this.router.navigate(['listSymptoms']);
  }

}
