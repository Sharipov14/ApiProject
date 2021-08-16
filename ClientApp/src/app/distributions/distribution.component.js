var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { DataService } from 'src/app/data.service';
import { Distribution } from './distributions';
let DistributionComponent = class DistributionComponent {
    constructor(dataService) {
        this.dataService = dataService;
        this.url = "api/distributions";
        this.distribution = new Distribution(); // изменяемый товар
        this.tableMode = true; // табличный режим
    }
    ngOnInit() {
        this.loadProjects(); // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadProjects() {
        this.dataService.getAll(this.url)
            .subscribe((data) => this.distributions = data);
    }
    // сохранение данных
    save() {
        if (this.distribution.id == null) {
            this.dataService.create(this.url, this.distribution)
                .subscribe((data) => this.distributions.push(data));
        }
        else {
            this.dataService.update(this.url, this.distribution)
                .subscribe(data => this.loadProjects());
        }
        this.cancel();
    }
    editProject(p) {
        this.distribution = p;
    }
    cancel() {
        this.distribution = new Distribution();
        this.tableMode = true;
        this.loadProjects();
    }
    delete(p) {
        this.dataService.delete(this.url, p.id)
            .subscribe(data => this.loadProjects());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
};
DistributionComponent = __decorate([
    Component({
        selector: 'distrib-comp',
        templateUrl: './distribution.component.html',
        providers: [DataService]
    })
], DistributionComponent);
export { DistributionComponent };
//# sourceMappingURL=distribution.component.js.map