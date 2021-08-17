var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { DataService } from 'src/app/data.service';
import { Project } from './project';
let ProjectComponent = class ProjectComponent {
    constructor(dataService) {
        this.dataService = dataService;
        this.url = "api/projects";
        this.project = new Project(); // изменяемый товар
        this.tableMode = true; // табличный режим
    }
    ngOnInit() {
        this.loadProjects(); // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadProjects() {
        this.dataService.getAll(this.url)
            .subscribe((data) => this.projects = data);
    }
    // сохранение данных
    save() {
        if (this.project.projectId == null) {
            this.dataService.create(this.url, this.project)
                .subscribe((data) => this.projects.push(data));
        }
        else {
            this.dataService.update(this.url, this.project)
                .subscribe(data => this.loadProjects());
        }
        this.cancel();
    }
    editProject(p) {
        this.project = p;
    }
    cancel() {
        this.project = new Project();
        this.tableMode = true;
    }
    delete(p) {
        this.dataService.delete(this.url, p.projectId)
            .subscribe(data => this.loadProjects());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
};
ProjectComponent = __decorate([
    Component({
        selector: 'project-comp',
        templateUrl: './project.component.html',
        providers: [DataService]
    })
], ProjectComponent);
export { ProjectComponent };
//# sourceMappingURL=poroject.component.js.map