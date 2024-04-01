package com.api.carpintech.unittests.services;

import static com.jayway.jsonpath.internal.path.PathCompiler.fail;
import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

import org.junit.jupiter.api.Test;

import com.api.carpintech.models.Financeiro;
import com.api.carpintech.services.FinanceiroService;

public class FinanceiroServiceTest {

FinanceiroService service = new FinanceiroService();

    @Test
    public void testCalcularLucro() {
        Financeiro financeiro = mock(Financeiro.class);
        when(financeiro.getCustosMateriais()).thenReturn(100.0);
        when(financeiro.getSalariosFuncionarios()).thenReturn(50.0);
        when(financeiro.getDespesasOperacionais()).thenReturn(20.0);
        when(financeiro.getPagamentosClientes()).thenReturn(150.0);

        assertEquals(100.0, service.calcularLucro(financeiro), 0.0);
    }

    @Test
    public void testCalcularBalanco() {
        Financeiro financeiro = mock(Financeiro.class);
        when(financeiro.getCustosMateriais()).thenReturn(100.0);
        when(financeiro.getSalariosFuncionarios()).thenReturn(50.0);
        when(financeiro.getDespesasOperacionais()).thenReturn(20.0);
        when(financeiro.getPagamentosClientes()).thenReturn(150.0);

        assertEquals(-50.0, service.calcularBalanco(financeiro), 0.0);
    }

    @Test
    public void testCalcularLucroLiquido() {
        Financeiro financeiro = mock(Financeiro.class);
        when(financeiro.getCustosMateriais()).thenReturn(100.0);
        when(financeiro.getSalariosFuncionarios()).thenReturn(50.0);
        when(financeiro.getDespesasOperacionais()).thenReturn(20.0);
        when(financeiro.getPagamentosClientes()).thenReturn(150.0);

        assertEquals(50.0, service.calcularLucroLiquido(financeiro), 0.0);
    }

}
