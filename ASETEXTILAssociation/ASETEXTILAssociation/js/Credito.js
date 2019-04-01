function calcularPlan() {
    var contenido = '<tbody>';
    var tasaInteres = $('#interes').val() / 100;
    var montoPrestamo = $('#monto').val();
    var duracionP = $('#plazo').val();
    //var cuotaMes = ( (tasaInteres * montoPrestamo) / ( 1 - ( Math.pow( ( 1 / ( 1 + tasaInteres ), duracionP ) ) ) ) );
    var cuotaArriba = tasaInteres * montoPrestamo;
    var negativo = 1 / Math.pow(1 + tasaInteres, duracionP);
    var coutaAbajo = 1 - negativo;
    var cuotaMes = (cuotaArriba / coutaAbajo).toFixed(2);
    var saldoInicial = montoPrestamo;
    var saldoFinal = 0;
    var intereses = 0;
    var amortizacion = 0;

    for (var inicio = 1; inicio <= duracionP; inicio++) {
        //Calculo el monto del interes para cada mes
        intereses = (saldoInicial * tasaInteres).toFixed(2);
        //Calculo el monto de la amortizacion para cada mes
        amortizacion = (cuotaMes - intereses).toFixed(2);
        //amortizacion = (907.75 - intereses).toFixed(2);
        //Calculo el monto del saldo final
        saldoFinal = (saldoInicial - amortizacion).toFixed(2);
        contenido += '<tr>';
        contenido += '<td>' + inicio + '</td>';
        contenido += '<td>' + saldoInicial + '</td>';
        contenido += '<td>' + amortizacion + '</td>';
        contenido += '<td>' + intereses + '</td>';
        contenido += '<td>' + cuotaMes + '</td>';
        if (inicio == duracionP) {
            contenido += '<td>' + 0 + '</td>';
        } else {
            contenido += '<td>' + saldoFinal + '</td>';
        }
        contenido += '</tr>';
        saldoInicial = saldoFinal;
    } //Fin del for
    contenido += '</tbody>';
    $('#tablaPagos').append(contenido);
}
