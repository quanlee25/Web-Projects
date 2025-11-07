document.addEventListener("DOMContentLoaded", function () {
    // Lấy thẻ chứa iframe video
    const iframe = document.querySelector("iframe");
    if (iframe) {
        iframe.setAttribute("allowfullscreen", "");
    }

    // Thêm hiệu ứng xem thêm nội dung (nếu cần)
    const shortPlot = document.querySelector(".movie-plot-short");
    const fullPlot = document.createElement("p");
    const toggleBtn = document.createElement("span");

    if (shortPlot) {
        const text = shortPlot.innerText;
        if (text.length > 120) {
            fullPlot.innerText = text;
            shortPlot.innerText = text.substring(0, 120) + "...";
            toggleBtn.innerText = "Xem thêm";
            toggleBtn.classList.add("toggle-text");

            toggleBtn.addEventListener("click", function () {
                const isExpanded = toggleBtn.innerText === "Thu gọn";
                if (isExpanded) {
                    shortPlot.innerText = text.substring(0, 120) + "...";
                    toggleBtn.innerText = "Xem thêm";
                } else {
                    shortPlot.innerText = text;
                    toggleBtn.innerText = "Thu gọn";
                }
            });

            shortPlot.insertAdjacentElement("afterend", toggleBtn);
        }
    }
});
