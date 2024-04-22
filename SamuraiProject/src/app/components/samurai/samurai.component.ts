import { Component } from '@angular/core';
import { Samurai } from '../../Models/Samurai'; //import the Samurai class
import { SamuraiService } from '../../Services/samurai.service';
import { GenericService } from '../../Services/generic.service';

@Component({
  selector: 'app-samurai',
  templateUrl: './samurai.component.html',
  styleUrl: './samurai.component.css'
})
export class SamuraiComponent {

  samurai: Samurai = new Samurai(); //create an instance of the Samurai class
  SamuraiList: Samurai[] = []; //create an array of Samurai objects
  showSamuraiList: boolean = false; //create a boolean variable to show or hide the SamuraiList

  constructor(private GenericService: GenericService<SamuraiService>) {}

  ngOnInit() {
    this.GetAllFromApi(); //call the GetAllFromApi method
  }

   GetAllFromApi() : void{
    this.GenericService.getAllFromApi('samurai').subscribe((data: any[]) => {
     this.SamuraiList = data;
      });

  }

  ShowList() : void{
    this.showSamuraiList = !this.showSamuraiList;
  }
}
