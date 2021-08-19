import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DataService } from './data.service';
import { AppComponent } from './app.component';
import { ProjectComponent } from './projects/poroject.component'
import { WorkerComponent } from './workers/worker.component'
import { DistributionComponent } from './distributions/distribution.component'
// import { PossibleProjectsComponent } from './possible-projects/possible-project.component'

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [AppComponent, ProjectComponent, WorkerComponent, DistributionComponent],
    providers: [DataService],
    bootstrap: [AppComponent]
})
export class AppModule { }