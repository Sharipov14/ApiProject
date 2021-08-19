import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/data.service';
import { Project } from './project';

@Component({
    selector: 'project-comp',
    templateUrl: './project.component.html',
    providers: [DataService]
})
export class ProjectComponent implements OnInit {

    private url = "api/project";

    project: Project = new Project();   // изменяемый товар
    projects: Project[];                // массив товаров
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) {}

    ngOnInit() {
        this.loadProjects();    // загрузка данных при старте компонента  
    }

    // получаем данные через сервис
    loadProjects() {
        this.dataService.getAll(this.url)
            .subscribe((data: Project[]) => this.projects = data);
    }
    // сохранение данных
    save() {       
        if (this.project.projectId == null) {
            this.dataService.create(this.url ,this.project)
                .subscribe((data: Project) => this.projects.push(data));
        } else {
            this.dataService.update(this.url ,this.project)
                .subscribe(data => this.loadProjects());
        }
        this.cancel();
    }
    editProject(p: Project) {
        this.project = p;
    }
    cancel() {
        this.project = new Project();
        this.tableMode = true;
    }
    delete(p: Project) {
        this.dataService.delete(this.url ,p.projectId)
            .subscribe(data => this.loadProjects());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}