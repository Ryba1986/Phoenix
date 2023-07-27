import notify from "devextreme/ui/notify";
import { toastDisplayTime } from "../config";

export function displayError(message: any, onshowing: Function = () => {}, onHidden: Function = () => {}): void {
   notify({
      message: message,
      type: "error",
      displayTime: toastDisplayTime,
      width: "auto",
      onShowing: onshowing,
      onHidden: onHidden,
   });
}
