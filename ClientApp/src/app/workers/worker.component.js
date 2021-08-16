var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { DataService } from 'src/app/data.service';
import { Worker } from './worker';
let WorkerComponent = class WorkerComponent {
    constructor(dataService) {
        this.dataService = dataService;
        this.url = "api/workers";
        this.worker = new Worker(); // изменяемый товар
        this.tableMode = true; // табличный режим
    }
    ngOnInit() {
        this.loadWorkers(); // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadWorkers() {
        this.dataService.getAll(this.url)
            .subscribe((data) => this.workers = data);
    }
    // сохранение данных
    save() {
        if (this.worker.workerId == null) {
            this.dataService.create(this.url, this.worker)
                .subscribe((data) => this.workers.push(data));
        }
        else {
            this.dataService.update(this.url, this.worker)
                .subscribe(data => this.loadWorkers());
        }
        this.cancel();
    }
    editWorker(w) {
        this.worker = w;
    }
    cancel() {
        this.worker = new Worker();
        this.tableMode = true;
    }
    delete(w) {
        this.dataService.delete(this.url, w.workerId)
            .subscribe(data => this.loadWorkers());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
};
WorkerComponent = __decorate([
    Component({
        selector: 'worker-comp',
        templateUrl: './worker.component.html',
        providers: [DataService]
    })
], WorkerComponent);
export { WorkerComponent };
//# sourceMappingURL=worker.component.js.map