import { Template } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { error } from 'protractor';
import { Medico } from '../models/medico';
import { MedicoService } from '../services/Medico.service';

@Component({
  selector: 'app-medico',
  templateUrl: './medico.component.html',
  styleUrls: ['./medico.component.css']
})
export class MedicoComponent implements OnInit {
  titlemedico = 'Médicos'

  public selectedMedico: Medico;
  public medicoForm: FormGroup;
  public modalRef: BsModalRef;

  public medicos: Medico[];
  //Carrega o Modal :Precisa Implementar
  openModal(template: TemplateRef<MedicoComponent>) {
    this.modalRef = this.modalService.show(template);
  }

  createForm() {
    this.medicoForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      especialidades: [''],
      crm: ['', Validators.required],
      telefone: ['', Validators.required]
    })
  }
  selectMedico(medico: Medico) {
    this.selectedMedico = medico;
    this.medicoForm.patchValue(medico)
  }
  back() {
    this.selectedMedico = null;
    this.carregaMedico();
  }
  submit() {
    this.saveMedico(this.medicoForm.value);
  }

  saveMedico(medico: Medico) {
    this.medicoservice.edit(medico).subscribe(
      (retorno: Medico) => {
        console.log(retorno);
        this.carregaMedico();
      },
      (error: any) => {
        console.log(error);
      }
    );
  }
  //Pega o Id do médico para excluir
  deleteMedico(id: number) {
    this.medicoservice.delete(id).subscribe(
      (modal: any) => {
        console.log(modal);
        this.carregaMedico();
      },
      (error: any) => {
        console.log(error);
      }
    );
  }
  carregaMedico() {
    this.medicoservice.getAll().subscribe(
      (medicos: Medico[]) => {
        this.medicos = medicos;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  constructor(private fb: FormBuilder, private modalService: BsModalService, private medicoservice: MedicoService) {
    this.createForm();
  }

  ngOnInit(): void {
    this.carregaMedico();
  }
}
