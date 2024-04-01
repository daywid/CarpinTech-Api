package com.api.carpintech.unittests.services;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.jupiter.api.Test;

import com.api.carpintech.models.Financeiro;
import com.api.carpintech.services.FinanceiroService;

public class FinanceiroServiceTest {
    
FinanceiroService service = new FinanceiroService();

    @Test
    void calcularLucro_deveRetornarZero_quandoOValorDoPagamentosForMenorQueASomaDosOutros() {
        Financeiro financeiro = new Financeiro(100, 200, 300, 99);

        double lucro = service.calcularLucro(financeiro);

        assertEquals(0, lucro);
    }

    @Test
    void calcularLucro_deveRetornarDiferencaEntrePagamentosEOutros_quandoOValorDoPagamentosForMaiorQueASomaDosOutros() {
        Financeiro financeiro = new Financeiro(100, 200, 300, 400);

        double lucro = service.calcularLucro(financeiro);

        assertEquals(100, lucro);
    }

    @Test
    void calcularBalanco_deveRetornarDiferencaEntrePagamentosEOutros_quandoOValorDoPagamentosForMenorQueASomaDosOutros() {
        Financeiro financeiro = new Financeiro(100, 200, 300, 99);

        double balanco = service.calcularBalanco(financeiro);

        assertEquals(401, balanco);
    }

    @Test
    void calcularBalanco_deveRetornarZero_quandoOValorDoPagamentosForMaiorQueASomaDosOutros() {
        Financeiro financeiro = new Financeiro(100, 200, 300, 400);

        double balanco = service.calcularBalanco(financeiro);

        assertEquals(0, balanco);
    }

    @Test
    void calcularLucroLiquido_deveRetornarZero_quandoOValorDoPagamentosForMenorQueASomaDosOutros() {
        Financeiro financeiro = new Financeiro(100, 200, 300, 99);

        double lucroLiquido = service.calcularLucroLiquido(financeiro);

        assertEquals(0, lucroLiquido);
    }

    @Test
    void calcularLucroLiquido_deveRetornarDiferencaEntrePagamentosEOutros_quandoOValorDoPagamentosForMaiorQueASomaDosOutros() {
        Financeiro financeiro = new Financeiro(100, 200, 300, 400);

        double lucroLiquido = service.calcularLucroLiquido(financeiro);

        assertEquals(60, lucroLiquido);
    }

}
