$(document).ready(function () {
    const STORAGE_KEY = 'networkTestHistory';
    const MAX_HISTORY_ITEMS = 10;

    // Initialize recent tests
    loadRecentTests();

    // Handle test type change
    $('#testTypeSelect').change(function () {
        if ($(this).val() === '1') { // PortCheck
            $('#portGroup').slideDown();
        } else {
            $('#portGroup').slideUp();
        }
    }).trigger('change');

    // Form submission
    $('#testForm').on('submit', function () {
        $('#loadingOverlay').addClass('active');
        $('#initialState').addClass('d-none');
        $('.test-result').removeClass('show');
    });

    // Run again button
    $('#runAgainBtn').on('click', function () {
        $('#testForm').trigger('submit');
    });

    // Save result button
    $('#saveResultBtn').on('click', function () {
        @if (ViewBag.Result != null) {
            var result = ViewBag.Result as NetworkTestApp.Models.NetworkTestResult;
            <text>
                saveTestResult({
                    host: '@result.Host',
                testType: '@result.TestType',
                success: @result.Success.ToString().ToLower(),
                message: '@result.Message',
                responseTime: @result.ResponseTime,
                testTime: '@result.TestTime.ToString("yyyy-MM-ddTHH:mm:ss")'
                    });
                alert('Test result saved to history!');
                loadRecentTests();
            </text>
        }
    });

    // Clear history button
    $('#clearHistoryBtn').on('click', function () {
        if (confirm('Are you sure you want to clear all history?')) {
            localStorage.removeItem(STORAGE_KEY);
            loadRecentTests();
        }
    });

    // Load recent tests from localStorage
    function loadRecentTests() {
        const history = getTestHistory();
        const container = $('#recentTestsContainer');

        if (history.length === 0) {
            container.html(`
                        <div class="empty-history">
                            <i class="fa-solid fa-inbox fa-2x mb-3"></i>
                            <p>No recent tests found</p>
                        </div>
                    `);
            return;
        }

        let html = '';
        history.forEach((test, index) => {
            const timeAgo = getTimeAgo(new Date(test.testTime));
            const badgeClass = test.success ? 'bg-success' : 'bg-danger';
            const statusText = test.success ? 'Success' : 'Failed';

            html += `
                        <div class="history-item" data-index="${index}">
                            <div class="d-flex justify-content-between align-items-center">
                                <div>
                                    <span class="test-type-badge">${test.testType}</span>
                                    <h6 class="mb-0 mt-1">${test.host}</h6>
                                    <small class="text-muted">${timeAgo}</small>
                                </div>
                                <div class="text-end">
                                    <span class="badge ${badgeClass}">${statusText}</span>
                                    <div class="text-dark fw-bold">${test.responseTime}ms</div>
                                </div>
                            </div>
                        </div>
                    `;
        });

        container.html(html);

        // Add click handlers to history items
        $('.history-item').on('click', function () {
            const index = $(this).data('index');
            const test = history[index];
            loadTestDetails(test);
        });
    }

    // Get test history from localStorage
    function getTestHistory() {
        try {
            const history = localStorage.getItem(STORAGE_KEY);
            return history ? JSON.parse(history) : [];
        } catch (e) {
            console.error('Error loading test history:', e);
            return [];
        }
    }

    // Save test result to localStorage
    function saveTestResult(testResult) {
        try {
            let history = getTestHistory();

            // Add new test to beginning of array
            history.unshift(testResult);

            // Limit to max items
            if (history.length > MAX_HISTORY_ITEMS) {
                history = history.slice(0, MAX_HISTORY_ITEMS);
            }

            localStorage.setItem(STORAGE_KEY, JSON.stringify(history));
        } catch (e) {
            console.error('Error saving test result:', e);
        }
    }

    // Load test details into form
    function loadTestDetails(test) {
        $('#Host').val(test.host);
        $('#TestType').val(test.testType);
        $('#Timeout').val(1000);

        if (test.testType === 'PortCheck') {
            const parts = test.host.split(':');
            if (parts.length > 1) {
                $('#Port').val(parts[1]);
            }
            $('#portGroup').show();
        } else {
            $('#portGroup').hide();
        }

        // Scroll to form
        $('html, body').animate({
            scrollTop: $('#testForm').offset().top - 100
        }, 500);
    }

    // Calculate time ago
    function getTimeAgo(date) {
        const now = new Date();
        const diff = now - date;
        const minutes = Math.floor(diff / 60000);
        const hours = Math.floor(diff / 3600000);
        const days = Math.floor(diff / 86400000);

        if (minutes < 1) return 'Just now';
        if (minutes < 60) return `${minutes} minute${minutes > 1 ? 's' : ''} ago`;
        if (hours < 24) return `${hours} hour${hours > 1 ? 's' : ''} ago`;
        return `${days} day${days > 1 ? 's' : ''} ago`;
    }

    // Auto-save result if this is a form submission
    @if (ViewBag.Result != null) {
        var result = ViewBag.Result as NetworkTestApp.Models.NetworkTestResult;
        <text>
            setTimeout(function() {
                saveTestResult({
                    host: '@result.Host',
                    testType: '@result.TestType',
                    success: @result.Success.ToString().ToLower(),
                    message: '@result.Message',
                    responseTime: @result.ResponseTime,
                    testTime: '@result.TestTime.ToString("yyyy-MM-ddTHH:mm:ss")'
                });
            loadRecentTests();
                }, 1000);
        </text>
    }
});