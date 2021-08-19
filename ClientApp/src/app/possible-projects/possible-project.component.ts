// import { Component, OnInit } from '@angular/core';
// import { DataService } from '../data.service';
// import { PossibleProjects } from './possible-projects';

// @Component({
//     selector: 'possible-comp',
//     templateUrl: './distribution.component.html',
//     providers: [DataService]
// })
// export class PossibleProjectsComponent implements OnInit {

//     private url = "api/possibleProjects";

//     possibleProject: PossibleProjects = new PossibleProjects();   // изменяемый товар
//     possibleProjects: PossibleProjects[];                // массив товаров
//     tableMode: boolean = true;          // табличный режим

//     constructor(private dataService: DataService) {}

//     ngOnInit() {
//         this.loadDistributions();    // загрузка данных при старте компонента  
//     }

//     // получаем данные через сервис
//     loadDistributions() {
//         this.dataService.getAll(this.url)
//             .subscribe((data: PossibleProjects[]) => this.possibleProjects = data);
//     }
//     // сохранение данных
//     save() {       
//         if (this.possibleProject.id == null) {
//             this.dataService.create(this.url, this.possibleProject)
//                 .subscribe((data: PossibleProjects) => this.possibleProjects.push(data));
//         } else {
//             this.dataService.update(this.url, this.possibleProject)
//                 .subscribe(data => this.loadDistributions());
//         }
//         this.cancel();
//     }
//     editDistribution(p: PossibleProjects) {
//         this.possibleProject = p;
//     }
//     cancel() {
//         this.possibleProject = new PossibleProjects();
//         this.tableMode = true;
//     }
//     delete(p: PossibleProjects) {
//         this.dataService.delete(this.url, p.id)
//             .subscribe(data => this.loadDistributions());
//     }
//     add() {
//         this.cancel();
//         this.tableMode = false;
//     }
// }