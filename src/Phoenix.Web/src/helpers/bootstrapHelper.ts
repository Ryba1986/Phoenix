import "bootstrap/js/dist/collapse";
import "bootstrap/js/dist/dropdown";

export function collapseNavBar(): void {
   document.getElementById("navbarSupportedContent")?.classList?.remove("show");
}
