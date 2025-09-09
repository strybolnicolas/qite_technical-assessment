
//* Angular
import { Component, inject } from "@angular/core";
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";

//* Ng-Zorro-Antd
import { NzButtonModule } from "ng-zorro-antd/button";
import { NzCheckboxModule } from "ng-zorro-antd/checkbox";
import { NzFormModule } from "ng-zorro-antd/form";
import { NzInputModule } from "ng-zorro-antd/input";


@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrl: "./login.component.scss",
  imports: [
    ReactiveFormsModule,
    NzButtonModule,
    NzCheckboxModule,
    NzFormModule, 
    NzInputModule,
  ],
})
export class LoginComponent {

  private fb = inject(NonNullableFormBuilder);
  validateForm = this.fb.group({
    username: this.fb.control("", [Validators.required]),
    password: this.fb.control("", [Validators.required]),
    remember: this.fb.control(true)
  });

  submitForm(): void {
    if (this.validateForm.valid) {
      console.log("submit", this.validateForm.value);
    } else {
      Object.values(this.validateForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }
  
}
