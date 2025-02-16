// 全局AJAX错误处理
$(document).ajaxError(function (event, jqxhr) {
    if (jqxhr.status === 401) {
        window.location.href = '/Account/Login';
    } else {
        alert(`请求失败: ${jqxhr.responseJSON?.message || '未知错误'}`);
    }
});

// 全选/反选功能
$('#selectAll').change(function () {
    $('tbody input[type="checkbox"]').prop('checked', $(this).prop('checked'));
});