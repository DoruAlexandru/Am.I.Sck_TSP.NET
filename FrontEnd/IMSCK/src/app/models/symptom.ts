import { Item } from "./item";

export interface Symptom {
  name: string;
  description: string;
  formControlName?: string;
  severities?: Item[];
}
