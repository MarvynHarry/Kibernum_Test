import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators,ReactiveFormsModule } from '@angular/forms';
import { Contact } from '../models/contact.model';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';


@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,  // <-- Ensure ReactiveFormsModule is imported here
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatButtonModule
  ]
})
export class ContactFormComponent {
  contactForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<ContactFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { contact: Contact | null } // <-- Inject data here
  ) {
    // Initialize the form with the passed data (if any)
    this.contactForm = this.fb.group({
      id: [data?.contact?.id || 0, Validators.nullValidator],
      name: [data?.contact?.name || '', Validators.required],
      phoneNumber: [data?.contact?.phoneNumber || '', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.contactForm.valid) {
      // Pass the form data back to the dialog's caller
      this.dialogRef.close(this.contactForm.value);
    }
  }

  onCancel(): void {
    // Close the dialog without passing any data
    this.dialogRef.close();
  }
}
