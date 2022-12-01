import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PoPageAction } from '@po-ui/ng-components';

@Component({
  selector: 'app-empresa-admin-lista',
  templateUrl: './empresa-admin-lista.component.html'
})
export class EmpresaAdminListaComponent implements OnInit {

  private irParaInclusao = () => this.router.navigate(['incluir'], { relativeTo: this.route });
  public acoes: Array<PoPageAction> = [
    { label: 'Nova Empresa', action: this.irParaInclusao.bind(this), icon: 'po-icon-plus' }
  ];

  constructor(
    private router: Router,
    private route: ActivatedRoute
    ) { }

  ngOnInit(): void {
  }

}
