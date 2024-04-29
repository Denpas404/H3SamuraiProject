import { Component } from '@angular/core';
import { Samurai } from '../../Models/Samurai';
import { GenericService } from '../../Services/generic.service';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SamuraiErrorsPipe } from "./pipe/SamuraiErrors.pipe";

@Component({
    selector: 'app-samurai',
    standalone: true,
    templateUrl: './samurai.component.html',
    styleUrl: './samurai.component.css',
    imports: [ReactiveFormsModule, CommonModule, FormsModule, SamuraiErrorsPipe]
})
export class SamuraiComponent {
  samurai: Samurai = new Samurai(); //create an instance of the Samurai class
  SamuraiList: Samurai[] = []; //create an array of Samurai objects
  showSamuraiList: boolean = false; //create a boolean variable to show or hide the SamuraiList

  registerForm!: FormGroup;
  submitted = false;

  temp: any = 'CanYouTest';
  name: string = 'kanBan';
  adr: any = 'Falkevej 45';


  constructor(
    private GenericService: GenericService<Samurai>,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.registerForm = this.fb.group({
      updateOn: "blur",
      name: [
        '',
        [
          Validators.required, //required
          Validators.minLength(4), //min length 4
          Validators.pattern(/^\S.*$/),
          Validators.pattern(/^.*\S$/),
          ],
          ],
          description: ['', Validators.required], //required
      age: ['', Validators.required],     //required
    });
  }



  onSubmit(): void {
    this.submitted = true;
    if (this.registerForm.invalid) {
      console.error('Form is invalid:', this.registerForm.errors);
      return;
    }
    console.log('Form submitted successfully:', this.registerForm.value);
    this.samurai.name = this.registerForm.value.name;
    this.samurai.age = this.registerForm.value.age;
    this.samurai.description = this.registerForm.value.description;
    console.log(this.samurai);
    this.AddSamuraiToApi();
    this.registerForm.reset();

    this.submitted = false;
  }

  GetAllFromApi(): void {
    this.GenericService.getAllFromApi('samurai').subscribe((data: any[]) => {
      this.SamuraiList = data;
    });
  }

  ShowList(): void {
    this.showSamuraiList = !this.showSamuraiList;
  }

  AddSamuraiToApi(): void {
    this.GenericService.create(this.samurai, 'samurai').subscribe(
      (data: Samurai) => {
        this.SamuraiList.push(data);
        console.log(data);
      }
    );
  }

  flemmingWeirdFunction() {
    let newTemp = this.temp[0] + this.temp[1] + this.temp[6];
    console.log(newTemp);

    let newName = this.name.substring(0, 3) + this.name.substring(3, 7);
    console.log(newName);

    let newAdr = '';

    //falkevej 45
    for (let i = 1; i < this.adr.length + 1; i++) {
      if (this.adr[i - 1] === ' ') {
        newAdr += this.adr[i];
      }
      if (i % 3 == 0) {
        newAdr += this.adr[i - 1];
      }
    }
    console.log(newAdr);
  }
}
