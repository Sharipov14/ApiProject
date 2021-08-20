import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { PossibleProjects } from './possible-projects';
import { Worker } from '../workers/worker'
import { Project } from '../projects/project';

@Component({
    selector: 'possible-comp',
    templateUrl: './possible-project.component.html',
    providers: [DataService]
})
export class PossibleProjectsComponent implements OnInit {


    private url = "api/possibleProjects";

    possibleProject: PossibleProjects = new PossibleProjects();   // изменяемый товар
    possibleProjects: PossibleProjects[];                // массив товаров
    arrWorkerFio: string[];
    arrProjectName: string[];
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) {}

    ngOnInit() {
        this.loadPossibleProjects();    // загрузка данных при старте компонента
    }

    // получаем данные через сервис
    loadPossibleProjects() {
        this.dataService.getAll(this.url)
            .subscribe((data: PossibleProjects[]) => this.possibleProjects = data);
    }
    loadWorkers() {
        if (this.arrWorkerFio == null) {
            this.dataService.getAll("api/workers/workerFio")
                .subscribe((date: string[]) => this.arrWorkerFio = date);
        }
    }
    loadProjects() {
        if (this.arrProjectName == null) {
            this.dataService.getAll("api/projects/projectName")
            .subscribe((date: string[]) => this.arrProjectName = date);
        }
    }
    // сохранение данных
    save() {       
        if (this.possibleProject.id == null) {
            this.dataService.create(this.url, this.possibleProject)
                .subscribe((data: PossibleProjects) => this.possibleProjects.push(data));
        } else {
            this.dataService.update(this.url, this.possibleProject)
                .subscribe(data => this.loadPossibleProjects());
        }
        this.cancel();
    }
    editPossibleProject(p: PossibleProjects) {
        this.possibleProject = p;
        this.loadWorkers();
        this.loadProjects();
    }
    cancel() {
        this.possibleProject = new PossibleProjects();
        this.tableMode = true;
    }
    delete(p: PossibleProjects) {
        this.dataService.delete(this.url, p.id)
            .subscribe(data => this.loadPossibleProjects());
    }
    add() {
        this.cancel();
        this.loadWorkers();
        this.loadProjects();
        this.tableMode = false;
    }
}