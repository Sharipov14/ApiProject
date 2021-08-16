import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
})
export class AppComponent {

    isButtons: boolean = true;
    isWorker: boolean = false;
    isProject: boolean = false;
    isDistribution: boolean = false;

    runWorkers() {
        this.isWorker = true;
        this.isProject = false;
        this.isDistribution = false;
    }

    runProjects() {
        this.isProject = true;
        this.isWorker = false;
        this.isDistribution = false;
    }

    runDistributions() {
        this.isDistribution = true;
        this.isProject = false;
        this.isWorker = false;
    }
}