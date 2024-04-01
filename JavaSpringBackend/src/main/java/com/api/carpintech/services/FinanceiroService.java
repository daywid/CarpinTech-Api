package com.api.carpintech.services;

import com.api.carpintech.models.Financeiro;

public class FinanceiroService {
    
    public double calcularLucro(Financeiro f)
    {
        if ((f.getCustosMateriais() + f.getSalariosFuncionarios() + f.getDespesasOperacionais()) > f.getPagamentosClientes())
        {
            return 0;
        }
        else
        {
            return f.getPagamentosClientes() - (f.getCustosMateriais() + f.getSalariosFuncionarios() + f.getDespesasOperacionais());
        }

    }

    // Método para calcular o Balanço
    public Double calcularBalanco(Financeiro f)
    {
        return f.getCustosMateriais() + f.getSalariosFuncionarios() + f.getDespesasOperacionais() - f.getPagamentosClientes();
    }

    // Método para calcular o Lucro Líquido
    public Double calcularLucroLiquido(Financeiro f)
    {
        return calcularLucro(f) - calcularBalanco(f);    
    }
    
}

