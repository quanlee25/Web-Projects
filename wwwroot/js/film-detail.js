document.addEventListener("DOMContentLoaded", function () {
    const toggleText = document.getElementById('toggleText');
    const shortEl = document.getElementById('moviePlotShort');
    const fullEl = document.getElementById('moviePlotFull');

    if (toggleText) {
        toggleText.addEventListener('click', function () {
            const isExpanded = toggleText.textContent === "Thu gọn";
            if (isExpanded) {
                shortEl.style.display = 'block';
                fullEl.style.display = 'none';
                toggleText.textContent = "Xem thêm";
            } else {
                shortEl.style.display = 'none';
                fullEl.style.display = 'block';
                toggleText.textContent = "Thu gọn";
            }
        });
    }

    // Make iframe allow fullscreen
    const iframe = document.querySelector('iframe');
    if (iframe) iframe.setAttribute('allowfullscreen', '');
});
