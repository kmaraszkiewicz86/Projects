import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { FibResultService } from 'src/app/services/fib-result.service';
import { FibResult } from 'src/app/models/fib-result.model';
import { FibRequest } from 'src/app/models/fib-request.model';

@Component({
  selector: 'app-add-form',
  templateUrl: './add-form.component.html',
  styleUrls: ['./add-form.component.css']
})
export class AddFormComponent implements OnInit {

  formGroup: FormGroup;

  addedItem: FibResult;

  private postErrorMessages: string[] = [];

  constructor(private formBuilder: FormBuilder,
    private service: FibResultService) { }

  get numberToCalculate() {
    return this.formGroup.get("numberToCalculate")
  }

  get isErrorMessagesExists() {
    console.log(this.errorMessages.length > 0 || this.postErrorMessages.length > 0);
    return this.errorMessages.length > 0 || this.postErrorMessages.length > 0;
  }

  get isAddedItemExists() {
    return this.addedItem != null
  }

  get errorMessages() {
    return this.postErrorMessages.concat(this.getFormErrorMessages());
  }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      numberToCalculate: ['', Validators.compose([
        Validators.required, Validators.min(2), Validators.max(100)
      ])]
    })
  }

  public add() {
    this.service.add({
      numberToCalculate: this.numberToCalculate.value
    } as FibRequest).subscribe(res => {
      this.addedItem = res;
    }, err => {
      this.postErrorMessages.push(err)
    });
  }

  private getFormErrorMessages(): string[] {
    let errorMessages: string[] = [];

    if ((this.numberToCalculate.dirty || this.numberToCalculate.touched) && this.numberToCalculate.invalid) {
      Object.keys(this.numberToCalculate.errors).forEach(errKey => {

        let error = this.numberToCalculate.errors[errKey]

        switch (errKey) {
          case "required":
            errorMessages.push("The field is required")
            break;

          case "min":
            errorMessages.push(`The field ${error.actual} must be less then ${error.min}`)
            break;

          case "max":
            errorMessages.push(`The field ${error.actual} must be less then ${error.max}`)
            break
        }
      });
    }
    return errorMessages;
  }

}
