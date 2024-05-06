$(document).ready(function () {
    var chartCreated = false;

    function createChart() {
        $.ajax({
            url: '@Url.Action("GrafikOlustur", "AdminLayout")',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                var ctx = document.getElementById("myAreaChart").getContext('2d');
                var myLineChart = new Chart(ctx, {
                    type: 'line',
                    data: {
                        labels: data.labels,
                        datasets: [{
                            label: "Rezervasyonlar",
                            data: data.values,
                            backgroundColor: 'rgba(78, 115, 223, 0.5)',
                            borderColor: 'rgba(78, 115, 223, 1)',
                            borderWidth: 2
                        }]
                    },
                    options: {
                        scales: {
                            y: {
                                beginAtZero: true
                            }
                        }
                    }
                });
                chartCreated = true;
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    if (!chartCreated) {
        createChart();
    }
});