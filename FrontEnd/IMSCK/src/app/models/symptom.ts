import { Severity } from "./severity";

export interface Symptom {
  name: string;
  description: string;
  formControlName?: string;
  severities?: Severity[];
}
