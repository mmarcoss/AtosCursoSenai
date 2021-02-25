import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Cidade } from '../models/cidade';
import { CidadeService } from '../services/cidade.service';

@Component({
  selector: 'app-cidade',
  templateUrl: './cidade.component.html',
  styleUrls: ['./cidade.component.css']
})

export class CidadeComponent implements OnInit {
  public selectedCidade: Cidade;
  public cidadeForm: FormGroup;
  public modalRef: BsModalRef;

  titlecidade = 'Cidades';
  public cidades: Cidade[];

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  createForm() {
    this.cidadeForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      estado: ['', Validators.required]
    })
  }

  back() {
    this.selectedCidade = null;
  }

  submit() {
    this.saveCidade(this.cidadeForm.value);
    this.loadCidade();
  }


  deleteCidade(id:number){
    this.cidadeservice.delete(id).subscribe(
      (modal:any) => {
        console.log(modal);
        this.loadCidade();
      },
      (error:any) => {
        console.log(error);
      }
    );
    
   }

  saveCidade(cidade: Cidade) {
    this.cidadeservice.edit(cidade).subscribe(
      (retorno: Cidade) => {
        console.log(retorno);
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  selectCidade(cidade: Cidade) {
    this.selectedCidade = cidade;
    this.cidadeForm.patchValue(cidade);
  }


  loadCidade() {
    this.cidadeservice.getAll().subscribe(
      (cidades: Cidade[]) => {
        this.cidades = cidades;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }


  constructor(private fb: FormBuilder, private modalService: BsModalService, private cidadeservice: CidadeService) {
    this.createForm();
  }

  ngOnInit(): void {
    this.loadCidade();
  }

}
