import { Component, EventEmitter, HostListener, Input, OnInit, Output, ViewChild } from '@angular/core';
import { PoStepComponent, PoStepperComponent } from '@po-ui/ng-components';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-step-conclusao',
  templateUrl: './step-conclusao.component.html'
})
export class StepConclusaoComponent implements OnInit {
  @ViewChild('stepClienteContatoform', { static: true }) stepClienteContatoform!: NgForm;
  @Input() stepper!: PoStepperComponent;
  @Input() valorServicos: number = 1700.55;
  @Output() confirmSetp: EventEmitter<void> = new EventEmitter();

  name: string = '';
  document: string = '';

  constructor() { }

  ngOnInit(): void {
  }

  voltarStep() {
    this.stepper.previous()
  }

  confirmarStep() {
    this.confirmSetp.emit();
  }
}
