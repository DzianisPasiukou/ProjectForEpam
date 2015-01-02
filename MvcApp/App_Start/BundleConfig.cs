using System.Web.Optimization;
using MvcApp.App_Start;

public class BundleConfig
{
    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-2.1.1.min.js",
                "~/Scripts/jquery.cookie.js",
                "~/Scripts/angular.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js",
                "~/Scripts/jquery.signalR-2.1.2.min.js",
                "~/signalr/hubs",
                "~/Scripts/angular-touch.js",
                "~/Scripts/myScripts/abn_tree_directive.js",
                "~/Scripts/myScripts/App.js",
                "~/Scripts/myScripts/catalogService.js",
                "~/Scripts/myScripts/noteInfoService.js",
                "~/Scripts/myScripts/userService.js",
                "~/Scripts/myScripts/chacteristicService.js",
                "~/Scripts/myScripts/catalogCtrl.js",
                "~/Scripts/myScripts/modalCompareCtrl.js",
                "~/Scripts/myScripts/recordCtrl.js",
                "~/Scripts/myScripts/modalRecordCompare.js",
                "~/Scripts/myScripts/addNoteCtrl.js",
                "~/Scripts/myScripts/resourceCtrl.js",
                "~/Scripts/myScripts/modalCharacteristic.js",
                "~/Scripts/myScripts/addFileCtrl.js",
                "~/Scripts/ui.bootstrap/ui-bootstrap-tpls-0.12.0.min.js",
                "~/Scripts/textAngularSetup.js",
                "~/Scripts/textAngular.js",
                "~/Scripts/dashboard/sb-admin-2.js",
                "~/Scripts/myScripts/mainCtrl.js",
                "~/Scripts/myScripts/messageCtrl.js",
                "~/Scripts/myScripts/usersInformationCtrl.js",
                "~/Scripts/myScripts/editUserCtrl.js",
                "~/Scripts/myScripts/Autocomplete.js",
                "~/Scripts/myScripts/chatCtrl.js",
                "~/Scripts/textAngular-sanitize.js",
                "~/Scripts/myScripts/loading-bar.js",
                "~/Scripts/myScripts/angular-bootstrap-lightbox.js",
                "~/Scripts/myScripts/lightBoxCtrl.js",
                "~/Scripts/myScripts/fileUploadService.js",
                "~/Scripts/video.js"));

        bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/Site.css",
                "~/Content/bootstrap.min.css",
                "~/Content/dashboard/sb-admin-2.css",
                "~/Content/dashboard/font-awesome.min.css",
                "~/Content/dashboard/MyStyle.css",
                "~/Content/abn_tree.css",
                "~/Content/recordCSS.css"));
    }
}