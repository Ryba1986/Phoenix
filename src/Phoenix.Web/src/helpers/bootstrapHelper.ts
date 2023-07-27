import "bootstrap/js/dist/collapse";

export function collapseNavBar(): void {
   document.getElementById("navbarSupportedContent")?.classList?.remove("show");
}
