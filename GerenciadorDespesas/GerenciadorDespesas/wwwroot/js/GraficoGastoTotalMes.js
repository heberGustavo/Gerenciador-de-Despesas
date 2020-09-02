$(".escolhaMes").on('change', function () {
    var mesId = $('.escolhaMes').val();

    $.ajax({
        url: "Despesas/GastosTotalMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (dados) {
            //Necessario remover o canvas para depois adiciona-lo, pq senão da BUG
            $('canvas#GraficoGastoTotalMes').remove();
            $('div.GraficoGastoTotalMes').append('<canvas id="GraficoGastoTotalMes" style="width: 400px; height: 400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastoTotalMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: ['Restante', 'Total Gasto'],
                    datasets: [{
                        labe: "Total Gasto",
                        backgroundColor: ['#27ae60', '#c0392b'],
                        data: [(dados.salario - dados.valorTotalGasto), dados.valorTotalGasto]
                    }],
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total gasto no Mês"
                    }
                }
            });
        }
    });
});


function CarregarDadosGastosTotalMes () {

    $.ajax({
        url: "Despesas/GastosTotalMes",
        method: "POST",
        data: { mesId: 1 },
        success: function (dados) {
            //Necessario remover o canvas para depois adiciona-lo, pq senão da BUG
            $('canvas#GraficoGastoTotalMes').remove();
            $('div.GraficoGastoTotalMes').append('<canvas id="GraficoGastoTotalMes" style="width: 400px; height: 400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastoTotalMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: ['Restante', 'Total Gasto'],
                    datasets: [{
                        labe: "Total Gasto",
                        backgroundColor: ['#27ae60', '#c0392b'],
                        data: [(dados.salario - dados.valorTotalGasto), dados.valorTotalGasto]
                    }],
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total gasto no Mês"
                    }
                }
            });
        }
    });
}