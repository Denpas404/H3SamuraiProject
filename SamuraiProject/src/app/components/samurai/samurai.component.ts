import { Component } from '@angular/core';
import { Samurai } from '../../Models/Samurai'; //import the Samurai class
import { SamuraiService } from '../../Services/samurai.service';

@Component({
  selector: 'app-samurai',
  templateUrl: './samurai.component.html',
  styleUrl: './samurai.component.css'
})
export class SamuraiComponent {

  samurai: Samurai = new Samurai(); //create an instance of the Samurai class
  SamuraiList: Samurai[] = []; //create an array of Samurai objects
  showSamuraiList: boolean = false; //create a boolean variable to show or hide the SamuraiList

  constructor(private SamuraiService: SamuraiService) {}

  ngOnInit() {
    this.GetAllFromApi(); //call the GetAllFromApi method
  }

   GetAllFromApi() : void{
    this.SamuraiService.getAllFromApi().subscribe((data: Samurai[]) => {
      data.forEach((samurai: Samurai) => {
        this.SamuraiList.push(samurai);
      });
      console.log(this.SamuraiList);
    });
  }

  ShowList() : void{
    this.showSamuraiList = !this.showSamuraiList;
  }
}
