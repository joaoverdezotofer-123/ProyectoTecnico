import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-personas',
  templateUrl: './personas.component.html',
  standalone: false,
  styleUrls: ['./personas.component.scss'],
})
export class PersonasComponent {
  personaForm: FormGroup;

  constructor(private fb: FormBuilder, private apiService: ApiService) {
    this.personaForm = this.fb.group({
      nombres: ['', Validators.required],
      apellidos: ['', Validators.required],
      numeroIdentificacion: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      tipoIdentificacion: ['', Validators.required],
    });
  }

  submit() {
    if (this.personaForm.valid) {
      this.apiService.createPersona(this.personaForm.value).subscribe({
        next: (response) => alert('Persona creada con éxito'),
        error: (err) => alert('Error al crear persona'),
      });
    }
  }
}
