
function deleteConfirm() {
    return confirm('您确定要删除吗，该操作无法撤销');
}

function preSubmit() {
    if ((document.getElementById("ctMain_ctType").value == "分类") &&
        !confirm("您未选择正确的文章分类\n这将导致这篇文章不会被加入前台文章列表\n是否继续？")) {
        return false;
    }
    return true;
}
