import { Component } from '@angular/core';
import { Samurai } from '../../Models/Samurai'; //import the Samurai class
import { SamuraiService } from '../../Services/samurai.service';
import { GenericService } from '../../Services/generic.service';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-samurai',
  imports: [ReactiveFormsModule, CommonModule, FormsModule],
  standalone: true,
  templateUrl: './samurai.component.html',
  styleUrl: './samurai.component.css',
})
export class SamuraiComponent {
  samurai: Samurai = new Samurai(); //create an instance of the Samurai class
  SamuraiList: Samurai[] = []; //create an array of Samurai objects
  showSamuraiList: boolean = false; //create a boolean variable to show or hide the SamuraiList

      registerForm!: FormGroup;
  submitted = false;

  constructor(
    private GenericService: GenericService<Samurai>,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    //this.GetAllFromApi(); //call the GetAllFromApi method
    this.registerForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(4)]], // Minimum length validation
      description: ['', Validators.required],
      age: ['', Validators.required],
    });
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


  //button in the form
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
}
