import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Categoria } from './models/categorias';
import { CategoriasService } from './services/categorias.service';

@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.css']
})
export class CategoriasComponent implements OnInit {

  info: boolean = false;

  public form : FormGroup;
    public listCategories: Array<Categoria> = [];
    public formUpdate: FormGroup;

  constructor(private  fb: FormBuilder, private catService: CategoriasService, private router: Router) { }

  get formControls(){

    return this.form.controls;

  }

  ngOnInit(): void {

    this.initForm();
    this.traerCat();
    this.reset();
  
  }

  initForm(){

    this.form = this.fb.group({

      Name : new FormControl('', [Validators.required,Validators.pattern('[a-zA-Z]*'),Validators.minLength(3)]),
      Descripcion : new FormControl('', [Validators.required,Validators.pattern('[a-zA-Z]*'),Validators.maxLength(30)])

    })

  }
  
  guardar(){

    var categories = new Categoria();
    categories.Name = this.form.get('Name')?.value
    categories.Descripcion = this.form.get('Descripcion')?.value

    this.catService.crearCat(categories).subscribe(res => {

      console.log('Se guardo la Categoria' + res)
      this.form.reset();
      this.traerCat();

    },
    error => console.error('Fallo'))

  }

  borrarForm(){

    this.form.reset();

  }

  traerCat(){

    this.catService.traerCategoriasTs().subscribe(res =>{
      this.listCategories = res;
    });

  }

  borrarCat(id: number) {

    this.catService.borrarCat(id).subscribe(
      () => this.ngOnInit()
      
    );
  }

  reset(){

    this.formUpdate = this.fb.group({

      Name : new FormControl('', [Validators.required,Validators.pattern('[a-zA-Z]*'),Validators.minLength(3)]),
      Descripcion : new FormControl('', [Validators.required,Validators.pattern('[a-zA-Z]*'),Validators.maxLength(30)])

    })

  }

  editarCat(Id : any) {

    let newCategory:Categoria = {

      Id : Id,
      Name : this.form.controls.Name.value,
      Descripcion : this.form.controls.Descripcion.value

    }

    this.catService.modificarCategoria(newCategory).subscribe(()=>{this.traerCat(),this.form.reset()});

  }
  }
