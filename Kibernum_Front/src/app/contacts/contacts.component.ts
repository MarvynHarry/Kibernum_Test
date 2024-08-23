import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ContactService } from '../services/contact.service';
import { Contact } from '../models/contact.model';
import { ContactFormComponent } from '../contact-form/contact-form.component';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';



@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    MatIconModule,  // <-- Add this import
    MatButtonModule,
    MatTableModule,
    MatToolbarModule,
    MatListModule
  ],
  providers: [ContactService]
})
export class ContactsComponent implements OnInit {
  contacts: Contact[] = [];
  displayedColumns: string[] = ['name', 'phoneNumber', 'actions'];

  constructor(private contactService: ContactService, private authService: AuthService, private dialog: MatDialog, private router: Router) {}

  ngOnInit(): void {
    this.loadContacts();
  }

  // Load contacts from the server
  loadContacts(): void {
    this.contactService.getContacts().subscribe(contacts => {
      this.contacts = contacts;
    });
  }

  // Open dialog to create a new contact
  addContact(): void {
    const dialogRef = this.dialog.open(ContactFormComponent, {
      data: { contact: null }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.contactService.createContact(result).subscribe(() => {
          this.loadContacts();
        });
      }
    });
  }

  // Open dialog to edit an existing contact
  editContact(contact: Contact): void {
    const dialogRef = this.dialog.open(ContactFormComponent, {
      width: '700px',
      data: { contact }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      if (result) {
        this.contactService.updateContact(result).subscribe(() => {
          this.loadContacts();
        });
      }
    });
  }

  // Delete a contact
  deleteContact(contact: Contact): void {
    if (confirm(`Are you sure you want to delete ${contact.name}?`)) {
      this.contactService.deleteContact(contact.id).subscribe(() => {
        this.loadContacts();
      });
    }
  }
  logout(): void {
    this.authService.logout();  // Clear authentication (e.g., remove token)
    this.router.navigate(['/login']);  // Redirect to login page
  }
}
