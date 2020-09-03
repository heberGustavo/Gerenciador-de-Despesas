$(".escolhaMes").on('change', function () {
    var mesId = $('.escolhaMes').val();

    $.ajax({
        url: "Despesas/GastoMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (dados) {
            //Necessario remover o canvas para depois adiciona-lo, pq senão da BUG
            $('canvas#GraficoGastoMes').remove();
            $('div.GraficoGastoMes').append('<canvas id="GraficoGastoMes" style="width: 400px; height: 400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastoMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: PegarTiposDespesas(dados),
                    datasets: [{
                        labe: "Gastos por despesa",
                        backgroundColor: PegarCores(dados.length),
                        hoverBackgroundColor: PegarCores(dados.length),
                        data: PegarValores(dados)
                    }],
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Gastos por despesa"
                    }
                }
            });
        }
    });
});

function CarregarDadosGastosMes () {
    var mesId = $('.escolhaMes').val();

    $.ajax({
        url: "Despesas/GastoMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (dados) {
            //Necessario remover o canvas para depois adiciona-lo, pq senão da BUG
            $('canvas#GraficoGastoMes').remove();
            $('div.GraficoGastoMes').append('<canvas id="GraficoGastoMes" style="width: 400px; height: 400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastoMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: PegarTiposDespesas(dados),
                    datasets: [{
                        labe: "Gastos por despesa",
                        backgroundColor: PegarCores(dados.length),
                        hoverBackgroundColor: PegarCores(dados.length),
                        data: PegarValores(dados)
                    }],
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Gastos por despesa"
                    }
                }
            });
        }
    });
};
