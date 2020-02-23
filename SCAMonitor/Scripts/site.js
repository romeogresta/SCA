function ativarCarregando(indExibir) {
	$(".divCarregando").css("display", indExibir ? "block" : "none");
}

$(document).ajaxStart(function () {
    ativarCarregando(true);
});

$(document).ajaxComplete(function () {
    ativarCarregando(false);
});