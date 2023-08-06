<script setup lang="ts">
import { PropType } from "vue";
import { useI18n } from "vue-i18n";
import { getDateTimeShortString } from "../../helpers/dateHelper";
import { getPumpStatus, getSectionStatus, isDomesticPlcType, isDoubleHeatingPlcType, isHeatingPlcType } from "../../helpers/plcHelper";
import { ClimatixDto } from "../../models/api/plcs/climatixs/dto/climatixDto";

const props = defineProps({
   data: {
      type: Object as PropType<Array<ClimatixDto>>,
      default: [],
      required: true,
   },
});

const { t } = useI18n();
</script>

<template>
   <div class="row">
      <div v-for="plc in props.data" class="col-12">
         <Card>
            <template #header>
               <div class="mt-1 text-muted">
                  {{ plc.deviceName }}
                  <div class="float-end">{{ getDateTimeShortString(plc.date) }}</div>
               </div>
            </template>
            <template #body>
               <!-- table -->
               <table class="table table-sm table-borderless table-striped d-lg-none">
                  <tbody>
                     <tr>
                        <td>{{ t("components.climatix.outsideTemp") }}</td>
                        <td class="text-end">{{ plc.outsideTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.climatix.chHighInletPresure") }}</td>
                        <td class="text-end">{{ plc.chHighInletPresure.toFixed(1) }}</td>
                        <td>bar</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.climatix.chHighOutletPresure") }}</td>
                        <td class="text-end">{{ plc.chHighOutletPresure.toFixed(1) }}</td>
                        <td>bar</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.climatix.ch1HeatCurveTemp") }}</td>
                        <td class="text-end">{{ plc.ch1HeatCurveTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.climatix.ch1LowInletTemp") }}</td>
                        <td class="text-end">{{ plc.ch1LowInletTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.climatix.ch1LowOutletTemp") }}</td>
                        <td class="text-end">{{ plc.ch1LowOutletTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.climatix.ch1LowOutletPresure") }}</td>
                        <td class="text-end">{{ plc.ch1LowOutletPresure.toFixed(1) }}</td>
                        <td>bar</td>
                     </tr>
                     <tr v-if="isDoubleHeatingPlcType(plc)">
                        <td>{{ t("components.climatix.ch2HeatCurveTemp") }}</td>
                        <td class="text-end">{{ plc.ch2HeatCurveTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr v-if="isDoubleHeatingPlcType(plc)">
                        <td>{{ t("components.climatix.ch2LowInletTemp") }}</td>
                        <td class="text-end">{{ plc.ch2LowInletTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr v-if="isDoubleHeatingPlcType(plc)">
                        <td>{{ t("components.climatix.ch2LowOutletTemp") }}</td>
                        <td class="text-end">{{ plc.ch2LowOutletTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr v-if="isDoubleHeatingPlcType(plc)">
                        <td>{{ t("components.climatix.ch2LowOutletPresure") }}</td>
                        <td class="text-end">{{ plc.ch2LowOutletPresure.toFixed(1) }}</td>
                        <td>bar</td>
                     </tr>
                     <tr v-if="isDomesticPlcType(plc)">
                        <td>{{ t("components.climatix.dhwTempSet") }}</td>
                        <td class="text-end">{{ plc.dhwTempSet.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr v-if="isDomesticPlcType(plc)">
                        <td>{{ t("components.climatix.dhwTemp") }}</td>
                        <td class="text-end">{{ plc.dhwTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                  </tbody>
               </table>
               <!-- graphic heating -->
               <!-- prettier-ignore -->
               <svg
                  v-if="isHeatingPlcType(plc)"
                  class="d-none d-lg-block"
                  version="1.1"
                  viewBox="0 0 501 67"
                  xmlns="http://www.w3.org/2000/svg"
                  xmlns:xlink="http://www.w3.org/1999/xlink"
               >
                  <defs>
                     <linearGradient id="a" x1="256" x2="256" y1="9.98e-5" y2="512" gradientTransform="matrix(.0387 0 0 .0387 17.2 154)" gradientUnits="userSpaceOnUse">
                        <stop stop-color="#2af598" offset="0"/>
                        <stop stop-color="#009efd" offset="1"/>
                     </linearGradient>
                     <linearGradient id="c" x1="221" x2="196" y1="151" y2="97.7" gradientTransform="matrix(.98 0 0 .835 54.2 -57)" gradientUnits="userSpaceOnUse">
                        <stop style="stop-color:#00f" offset="0"/>
                        <stop style="stop-color:#a00" offset=".584"/>
                        <stop style="stop-color:#f00" offset="1"/>
                     </linearGradient>
                     <linearGradient id="b" x1="256" x2="256" y1="9.98e-5" y2="512" gradientTransform="matrix(.0322 0 0 .0322 496 6.28)" gradientUnits="userSpaceOnUse" xlink:href="#a"/>
                  </defs>
                  <g transform="translate(-16.6 -4.25)">
                     <text x="200.04912" y="42.26754" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="200.04912" y="42.26754">{{ plc.ch1ValvePosition.toFixed(1) }} %</tspan></text>
                     <text x="297.72708" y="46.519512" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve">          <tspan x="297.72708" y="46.519512">{{ plc.ch1LowOutletPresure.toFixed(1) }} Bar</tspan></text>
                     <g transform="translate(-.15 3.18)">
                        <g transform="matrix(1.12 0 0 1.12 249 -60.9)" style="stroke-width:.889">
                           <g transform="matrix(.00977 0 0 .00977 41.2 72.3)" style="stroke-width:24.1">
                              <g style="stroke-width:24.1">
                                 <g style="stroke-width:24.1">
                                    <path d="m276 318v-167h-39.4v167c-22.9 8.13-39.4 30-39.4 55.7 0 32.6 26.5 59.1 59.1 59.1s59.1-26.5 59.1-59.1c.001-25.7-16.5-47.6-39.4-55.7zm-19.7 75.4c-10.9 0-19.7-8.83-19.7-19.7s8.83-19.7 19.7-19.7 19.7 8.83 19.7 19.7-8.83 19.7-19.7 19.7z" style="stroke-width:24.1"/>
                                    <path d="m354 278v-179c0-54.3-44.2-98.5-98.5-98.5s-98.5 44.2-98.5 98.5v179c-25.1 25.7-39.4 60.3-39.4 96.5.001 76 61.8 138 138 138s138-61.8 138-138c0-36.1-14.3-70.8-39.4-96.5zm-98.5 195c-54.3 0-98.5-44.2-98.5-98.5 0-28 12-54.7 32.8-73.4l6.56-5.87v-196c0-32.6 26.5-59.1 59.1-59.1s59.1 26.5 59.1 59.1v196l6.56 5.87c20.9 18.7 32.8 45.4 32.8 73.4 0 54.3-44.2 98.5-98.5 98.5z" style="stroke-width:24.1"/>
                                 </g>
                              </g>
                           </g>
                           <path d="m43.7 71.3c-1.93 0-3.5 1.57-3.5 3.5 0 1.59 1.06 2.93 2.51 3.36v.912c0 .129.105.234.234.234h1.51c.129 0 .234-.105.234-.234v-.912c1.45-.427 2.51-1.77 2.51-3.36-1.6e-5-1.93-1.57-3.5-3.5-3.5zm.519 7.53h-1.04v-.574c.343.051.695.051 1.04 0zm-.519-1c-1.67 0-3.03-1.36-3.03-3.03 0-1.67 1.36-3.03 3.03-3.03s3.03 1.36 3.03 3.03c0 1.67-1.36 3.03-3.03 3.03z" style="stroke-width:.235"/>
                        </g>
                     </g>
                     <text x="297.59531" y="19.889423" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="297.59531" y="19.889423">{{ plc.ch1LowInletTemp.toFixed(1) }} °C</tspan></text>
                     <g transform="translate(30.6 30.2)">
                        <g transform="matrix(1.12 0 0 1.12 249 -60.9)" style="stroke-width:.889">
                           <g transform="matrix(.00977 0 0 .00977 41.2 72.3)" style="stroke-width:24.1">
                              <g style="stroke-width:24.1">
                                 <g style="stroke-width:24.1">
                                    <path d="m276 318v-167h-39.4v167c-22.9 8.13-39.4 30-39.4 55.7 0 32.6 26.5 59.1 59.1 59.1s59.1-26.5 59.1-59.1c.001-25.7-16.5-47.6-39.4-55.7zm-19.7 75.4c-10.9 0-19.7-8.83-19.7-19.7s8.83-19.7 19.7-19.7 19.7 8.83 19.7 19.7-8.83 19.7-19.7 19.7z" style="stroke-width:24.1"/>
                                    <path d="m354 278v-179c0-54.3-44.2-98.5-98.5-98.5s-98.5 44.2-98.5 98.5v179c-25.1 25.7-39.4 60.3-39.4 96.5.001 76 61.8 138 138 138s138-61.8 138-138c0-36.1-14.3-70.8-39.4-96.5zm-98.5 195c-54.3 0-98.5-44.2-98.5-98.5 0-28 12-54.7 32.8-73.4l6.56-5.87v-196c0-32.6 26.5-59.1 59.1-59.1s59.1 26.5 59.1 59.1v196l6.56 5.87c20.9 18.7 32.8 45.4 32.8 73.4 0 54.3-44.2 98.5-98.5 98.5z" style="stroke-width:24.1"/>
                                 </g>
                              </g>
                           </g>
                           <path d="m43.7 71.3c-1.93 0-3.5 1.57-3.5 3.5 0 1.59 1.06 2.93 2.51 3.36v.912c0 .129.105.234.234.234h1.51c.129 0 .234-.105.234-.234v-.912c1.45-.427 2.51-1.77 2.51-3.36-1.6e-5-1.93-1.57-3.5-3.5-3.5zm.519 7.53h-1.04v-.574c.343.051.695.051 1.04 0zm-.519-1c-1.67 0-3.03-1.36-3.03-3.03 0-1.67 1.36-3.03 3.03-3.03s3.03 1.36 3.03 3.03c0 1.67-1.36 3.03-3.03 3.03z" style="stroke-width:.235"/>
                        </g>
                     </g>
                     <text x="328.36539" y="46.8834" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="328.36539" y="46.8834">{{ plc.ch1LowOutletTemp.toFixed(1) }} °C</tspan></text>
                     <text x="297.59531" y="11.716424" style="fill:#ff0000;font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="297.59531" y="11.716424">{{ plc.ch1HeatCurveTemp.toFixed(1) }} °C</tspan></text>
                     <g transform="matrix(1.01 0 0 1.01 348 13.4)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.01 0 0 1.01 401 13.4)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(.17 0 0 .171 468 22.8)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <rect x="270" y="30.9" width="236" height="2" style="fill:#c80000;stroke-width:.368"/>
                     <g transform="matrix(.17 0 0 .171 468 49.4)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <g transform="matrix(1.01 0 0 1.01 348 40)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.5 0 0 1.49 310 -66.9)" style="stroke-width:.779">
                        <rect x="69.1" y="74.5" width="5.35" height="8.2" ry="1.56" style="fill:none;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.362;stroke:#000"/>
                        <path d="m69.1 78.6 5.31-.1" style="fill:none;stroke-width:.284;stroke:#000"/>
                        <rect x="71.2" y="82.8" width="1.17" height=".797" ry="0" style="fill:none;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.206;stroke:#000"/>
                     </g>
                     <rect x="270" y="57.8" width="236" height="2" style="fill:#1300e3;stroke-width:.368"/>
                     <g transform="matrix(1.01 0 0 1.01 33.3 13.1)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <text x="20.041454" y="45.917336" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="20.041454" y="45.917336" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265">{{ t('components.climatix.network') }}</tspan></text>
                     <g transform="matrix(1.01 0 0 1.01 65.5 13.1)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(.0176 0 0 .0176 111 22.4)" style="stroke-width:15.1">
                        <path d="m256 64.3c-88 0-160 71.6-160 160s71.6 160 160 160 160-71.6 160-160-71.6-160-160-160zm102 240-5.76-5.76c-5.86-5.86-15.4-5.86-21.2-.005-5.86 5.86-5.86 15.4-.005 21.2l5.76 5.77c-22.1 17.5-50 28-80.4 28s-58.3-10.5-80.4-28l5.76-5.77c5.86-5.86 5.85-15.4-.005-21.2s-15.4-5.85-21.2.005l-5.76 5.76c-14.6-18.4-24.3-40.9-27.1-65.4h8.23c8.28 0 15-6.72 15-15s-6.72-15-15-15h-8.23c2.84-24.5 12.5-47 27.1-65.4l5.76 5.76c5.86 5.86 15.4 5.86 21.2.005 5.86-5.86 5.86-15.4.005-21.2l-5.76-5.77c18.4-14.6 40.9-24.3 65.4-27.1v8.23c0 8.28 6.72 15 15 15s15-6.72 15-15v-8.23c24.5 2.84 47 12.5 65.4 27.1l-5.76 5.77c-5.86 5.86-5.85 15.4.005 21.2 5.86 5.86 15.4 5.85 21.2-.005l5.76-5.76c14.6 18.4 24.3 40.9 27.1 65.4h-8.23c-8.28 0-15 6.72-15 15s6.72 15 15 15h8.23c-2.84 24.5-12.5 47-27.1 65.4z" style="stroke-width:15.1"/>
                        <path d="m261 197-56.2 56.2c-5.86 5.86-5.86 15.4 0 21.2 5.86 5.86 15.4 5.86 21.2 0l56.2-56.2c5.86-5.86 5.86-15.4 0-21.2-5.86-5.86-15.4-5.86-21.2 0z" style="stroke-width:15.1"/>
                        <path d="m256 0c-123 0-224 100-224 224 0 102 67.9 187 161 215v58.4c0 8.28 6.72 15 15 15h96.4c8.28 0 15-6.72 15-15v-58.4c92.8-27.3 161-113 161-215-.001-123-100-224-224-224zm33.2 482h-66.4v-36.7c21.9 3.27 44.5 3.27 66.4 0zm-33.2-64.3c-107 0-194-87-194-194s87-194 194-194 194 87 194 194-87 194-194 194z" style="stroke-width:15.1"/>
                     </g>
                     <rect x="26.1" y="30.9" width="221" height="2" style="fill:#e70000;stroke-width:.341"/>
                     <path d="m19.5 30v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <g transform="matrix(1.01 0 0 1.01 33 40.3)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(.0176 0 0 .0176 111 49.4)" style="stroke-width:15.1">
                        <path d="m256 64.3c-88 0-160 71.6-160 160s71.6 160 160 160 160-71.6 160-160-71.6-160-160-160zm102 240-5.76-5.76c-5.86-5.86-15.4-5.86-21.2-.005-5.86 5.86-5.86 15.4-.005 21.2l5.76 5.77c-22.1 17.5-50 28-80.4 28s-58.3-10.5-80.4-28l5.76-5.77c5.86-5.86 5.85-15.4-.005-21.2s-15.4-5.85-21.2.005l-5.76 5.76c-14.6-18.4-24.3-40.9-27.1-65.4h8.23c8.28 0 15-6.72 15-15s-6.72-15-15-15h-8.23c2.84-24.5 12.5-47 27.1-65.4l5.76 5.76c5.86 5.86 15.4 5.86 21.2.005 5.86-5.86 5.86-15.4.005-21.2l-5.76-5.77c18.4-14.6 40.9-24.3 65.4-27.1v8.23c0 8.28 6.72 15 15 15s15-6.72 15-15v-8.23c24.5 2.84 47 12.5 65.4 27.1l-5.76 5.77c-5.86 5.86-5.85 15.4.005 21.2 5.86 5.86 15.4 5.85 21.2-.005l5.76-5.76c14.6 18.4 24.3 40.9 27.1 65.4h-8.23c-8.28 0-15 6.72-15 15s6.72 15 15 15h8.23c-2.84 24.5-12.5 47-27.1 65.4z" style="stroke-width:15.1"/>
                        <path d="m261 197-56.2 56.2c-5.86 5.86-5.86 15.4 0 21.2 5.86 5.86 15.4 5.86 21.2 0l56.2-56.2c5.86-5.86 5.86-15.4 0-21.2-5.86-5.86-15.4-5.86-21.2 0z" style="stroke-width:15.1"/>
                        <path d="m256 0c-123 0-224 100-224 224 0 102 67.9 187 161 215v58.4c0 8.28 6.72 15 15 15h96.4c8.28 0 15-6.72 15-15v-58.4c92.8-27.3 161-113 161-215-.001-123-100-224-224-224zm33.2 482h-66.4v-36.7c21.9 3.27 44.5 3.27 66.4 0zm-33.2-64.3c-107 0-194-87-194-194s87-194 194-194 194 87 194 194-87 194-194 194z" style="stroke-width:15.1"/>
                     </g>
                     <g transform="matrix(.0176 0 0 .0176 293 49.2)" style="stroke-width:15.1">
                        <path d="m256 64.3c-88 0-160 71.6-160 160s71.6 160 160 160 160-71.6 160-160-71.6-160-160-160zm102 240-5.76-5.76c-5.86-5.86-15.4-5.86-21.2-.005-5.86 5.86-5.86 15.4-.005 21.2l5.76 5.77c-22.1 17.5-50 28-80.4 28s-58.3-10.5-80.4-28l5.76-5.77c5.86-5.86 5.85-15.4-.005-21.2s-15.4-5.85-21.2.005l-5.76 5.76c-14.6-18.4-24.3-40.9-27.1-65.4h8.23c8.28 0 15-6.72 15-15s-6.72-15-15-15h-8.23c2.84-24.5 12.5-47 27.1-65.4l5.76 5.76c5.86 5.86 15.4 5.86 21.2.005 5.86-5.86 5.86-15.4.005-21.2l-5.76-5.77c18.4-14.6 40.9-24.3 65.4-27.1v8.23c0 8.28 6.72 15 15 15s15-6.72 15-15v-8.23c24.5 2.84 47 12.5 65.4 27.1l-5.76 5.77c-5.86 5.86-5.85 15.4.005 21.2 5.86 5.86 15.4 5.85 21.2-.005l5.76-5.76c14.6 18.4 24.3 40.9 27.1 65.4h-8.23c-8.28 0-15 6.72-15 15s6.72 15 15 15h8.23c-2.84 24.5-12.5 47-27.1 65.4z" style="stroke-width:15.1"/>
                        <path d="m261 197-56.2 56.2c-5.86 5.86-5.86 15.4 0 21.2 5.86 5.86 15.4 5.86 21.2 0l56.2-56.2c5.86-5.86 5.86-15.4 0-21.2-5.86-5.86-15.4-5.86-21.2 0z" style="stroke-width:15.1"/>
                        <path d="m256 0c-123 0-224 100-224 224 0 102 67.9 187 161 215v58.4c0 8.28 6.72 15 15 15h96.4c8.28 0 15-6.72 15-15v-58.4c92.8-27.3 161-113 161-215-.001-123-100-224-224-224zm33.2 482h-66.4v-36.7c21.9 3.27 44.5 3.27 66.4 0zm-33.2-64.3c-107 0-194-87-194-194s87-194 194-194 194 87 194 194-87 194-194 194z" style="stroke-width:15.1"/>
                     </g>
                     <rect x="26.3" y="57.8" width="221" height="2" style="fill:#450097;stroke-width:.34"/>
                     <path d="m19.6 57v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <g transform="matrix(1.01 0 0 1.01 65.3 40.3)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <circle cx="313" cy="28.3" r="0" style="fill:#fff;stroke-width:.074;stroke:#000"/>
                     <g transform="translate(172 13.4)">
                        <ellipse cx="219" cy="18.7" rx="5.85" ry="5.85" :fill="getPumpStatus(plc.ch1PumpAlarm, plc.ch1PumpStatus)" style="stroke-width:.3;stroke:#000"/>
                        <path d="m217 24.1 7.92-4.09" style="fill:none;stroke-width:.3;stroke:#000"/>
                        <path d="m217 13.2 7.92 4.09" style="fill-rule:evenodd;stroke-width:.3;stroke:#000"/>
                     </g>
                     <path d="m505 30.1v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <path d="m505 57v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <text x="513.12549" y="47.578751" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="513.12549" y="47.578751" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">{{ t('components.climatix.ch') }}</tspan></text>
                     <g transform="matrix(1.33 0 0 1.33 104 -80.3)" style="stroke-width:.753">
                        <rect x="66.6" y="102" width="11.2" height="5.65" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path d="m66.6 102v5.58l11.1-5.58v5.58z" fill="none" stroke="#000" style="fill:#ffa400;stroke-width:.199"/>
                        <path d="m72.1 105c0-4.78-.0668-4.86-.0668-4.86" style="fill:none;stroke-width:.199px;stroke:#000"/>
                        <circle cx="72.1" cy="97.2" r="2.87" style="fill:#a7a7a7;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.35;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.13 0 0 .986 67.7 -22.8)" style="stroke-width:1.07">
                        <rect x="86.7" y="53.7" width="7.28" height="3.57" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path d="m86.7 53.7v3.57l7.28-3.57v3.57z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.283"/>
                     </g>
                     <g transform="matrix(1.13 0 0 .986 67.7 4.05)" style="stroke-width:1.07">
                        <rect x="86.7" y="53.7" width="7.28" height="3.57" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path d="m86.7 53.7v3.57l7.28-3.57v3.57z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.283"/>
                     </g>
                     <rect x="246" y="24.5" width="25.3" height="44.5" ry="4.31" style="fill:url(#c);stroke-width:.266"/>
                     <text x="258.54254" y="48.733189" style="font-family:sans-serif;font-size:7.06px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="258.54254" y="48.733189" style="fill:#ffffff;font-family:sans-serif;font-size:7.06px;font-weight:bold;stroke-width:.265;text-align:center;text-anchor:middle" :visibility="getSectionStatus(plc.ch1Status)">{{ t('components.climatix.ch1Short') }}</tspan></text>
                     <text x="115.39965" y="20.126001" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="115.39965" y="20.126001">{{ plc.chHighInletPresure.toFixed(1) }} Bar</tspan></text>
                     <text x="115.11905" y="47.033669" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="115.11905" y="47.033669">{{ plc.chHighOutletPresure.toFixed(1) }} Bar</tspan></text>
                     <text transform="translate(-74.5 64.9)" x="568.32159" y="-47.113564" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;inline-size:133.935;line-height:1.25;stroke-width:.265;text-align:end;text-anchor:end;white-space:pre" xml:space="preserve"><tspan x="568.32159" y="-47.113564">{{ plc.outsideTemp.toFixed(1) }} °C</tspan></text>
                     <path d="m509 19.8c0 .355-.288.643-.643.643-.355 0-.643-.288-.643-.643 0-.355.288-.643.643-.643.355 0 .643.288.643.643zm2.38-3.6h1.58v-1.29h-1.58zm0-3.54v1.29h1.58v-1.29zm0 5.79h1.58v-1.29h-1.58zm-.965-.731c.548.559.868 1.32.868 2.08 0 1.63-1.33 2.96-2.96 2.96s-2.96-1.33-2.96-2.96c0-.764.319-1.52.866-2.08l.002-3.93c0-1.15.938-2.09 2.09-2.09 1.15 0 2.09.938 2.09 2.09zm-.418 2.08c0-.489-.237-.977-.635-1.3l-.234-.193v-4.52c0-.443-.361-.804-.804-.804-.443 0-.804.361-.804.804l-.002 4.52-.233.193c-.396.328-.633.815-.633 1.3 0 .922.75 1.67 1.67 1.67.922 0 1.67-.75 1.67-1.67zm-5.95 1.67h-4.02c-.355 0-.643-.289-.643-.643v-7.93l5.34-4.87 2.61 2.38h1.91l-4.51-4.12-8.24 7.52.867.95.749-.683v6.75c0 1.06.865 1.93 1.93 1.93h5.26c-.36-.37-.653-.805-.86-1.29z" fill="url(#a)" style="fill:url(#b);stroke-width:.0549"/>
                  </g>
               </svg>
               <!-- graphic double heating -->
               <!-- prettier-ignore -->
               <svg
                  v-if="isDoubleHeatingPlcType(plc)"
                  class="d-none d-lg-block"
                  version="1.1"
                  viewBox="0 0 501 122"
                  xmlns="http://www.w3.org/2000/svg"
                  xmlns:xlink="http://www.w3.org/1999/xlink"
               >
                  <defs>
                     <linearGradient id="b">
                        <stop style="stop-color:#00f" offset="0"/>
                        <stop style="stop-color:#a00" offset=".584"/>
                        <stop style="stop-color:#f00" offset="1"/>
                     </linearGradient>
                     <linearGradient id="a" x1="256" x2="256" y1="9.98e-5" y2="512" gradientTransform="matrix(.0387 0 0 .0387 17.2 154)" gradientUnits="userSpaceOnUse">
                        <stop stop-color="#2af598" offset="0"/>
                        <stop stop-color="#009efd" offset="1"/>
                     </linearGradient>
                     <linearGradient id="c" x1="221" x2="196" y1="151" y2="97.7" gradientTransform="matrix(.98 0 0 .835 54.2 -2.5)" gradientUnits="userSpaceOnUse" xlink:href="#b"/>
                     <linearGradient id="e" x1="221" x2="196" y1="151" y2="97.7" gradientTransform="matrix(.98 0 0 .835 54.2 -57)" gradientUnits="userSpaceOnUse" xlink:href="#b"/>
                     <linearGradient id="d" x1="256" x2="256" y1="9.98e-5" y2="512" gradientTransform="matrix(.0322 0 0 .0322 496 6.28)" gradientUnits="userSpaceOnUse" xlink:href="#a"/>
                  </defs>
                  <g transform="translate(-16.6 -4.25)">
                     <text x="199.94214" y="94.78157" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="199.94214" y="94.78157">{{ plc.ch2ValvePosition.toFixed(1) }} %</tspan></text>
                     <text x="200.04912" y="42.26754" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="200.04912" y="42.26754">{{ plc.ch1ValvePosition.toFixed(1) }} %</tspan></text>
                     <text x="297.73947" y="74.870934" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="297.73947" y="74.870934">{{ plc.ch2LowInletTemp.toFixed(1) }} °C</tspan></text>
                     <text x="297.73947" y="67.756256" style="fill:#ff0000;font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="297.73947" y="67.756256">{{ plc.ch2HeatCurveTemp.toFixed(1) }} °C</tspan></text>
                     <text x="297.72708" y="46.519512" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve">          <tspan x="297.72708" y="46.519512">{{ plc.ch1LowOutletPresure.toFixed(1) }} Bar</tspan></text>
                     <text x="297.99088" y="101.66486" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve">          <tspan x="297.99088" y="101.66486">{{ plc.ch2LowOutletPresure.toFixed(1) }} Bar</tspan></text>
                     <g transform="translate(-.15 3.18)">
                        <g transform="matrix(1.12 0 0 1.12 249 -60.9)" style="stroke-width:.889">
                           <g transform="matrix(.00977 0 0 .00977 41.2 72.3)" style="stroke-width:24.1">
                              <g style="stroke-width:24.1">
                                 <g style="stroke-width:24.1">
                                    <path d="m276 318v-167h-39.4v167c-22.9 8.13-39.4 30-39.4 55.7 0 32.6 26.5 59.1 59.1 59.1s59.1-26.5 59.1-59.1c.001-25.7-16.5-47.6-39.4-55.7zm-19.7 75.4c-10.9 0-19.7-8.83-19.7-19.7s8.83-19.7 19.7-19.7 19.7 8.83 19.7 19.7-8.83 19.7-19.7 19.7z" style="stroke-width:24.1"/>
                                    <path d="m354 278v-179c0-54.3-44.2-98.5-98.5-98.5s-98.5 44.2-98.5 98.5v179c-25.1 25.7-39.4 60.3-39.4 96.5.001 76 61.8 138 138 138s138-61.8 138-138c0-36.1-14.3-70.8-39.4-96.5zm-98.5 195c-54.3 0-98.5-44.2-98.5-98.5 0-28 12-54.7 32.8-73.4l6.56-5.87v-196c0-32.6 26.5-59.1 59.1-59.1s59.1 26.5 59.1 59.1v196l6.56 5.87c20.9 18.7 32.8 45.4 32.8 73.4 0 54.3-44.2 98.5-98.5 98.5z" style="stroke-width:24.1"/>
                                 </g>
                              </g>
                           </g>
                           <path d="m43.7 71.3c-1.93 0-3.5 1.57-3.5 3.5 0 1.59 1.06 2.93 2.51 3.36v.912c0 .129.105.234.234.234h1.51c.129 0 .234-.105.234-.234v-.912c1.45-.427 2.51-1.77 2.51-3.36-1.6e-5-1.93-1.57-3.5-3.5-3.5zm.519 7.53h-1.04v-.574c.343.051.695.051 1.04 0zm-.519-1c-1.67 0-3.03-1.36-3.03-3.03 0-1.67 1.36-3.03 3.03-3.03s3.03 1.36 3.03 3.03c0 1.67-1.36 3.03-3.03 3.03z" style="stroke-width:.235"/>
                        </g>
                     </g>
                     <text x="297.59531" y="19.889423" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="297.59531" y="19.889423">{{ plc.ch1LowInletTemp.toFixed(1) }} °C</tspan></text>
                     <g transform="translate(30.6 30.2)">
                        <g transform="matrix(1.12 0 0 1.12 249 -60.9)" style="stroke-width:.889">
                           <g transform="matrix(.00977 0 0 .00977 41.2 72.3)" style="stroke-width:24.1">
                              <g style="stroke-width:24.1">
                                 <g style="stroke-width:24.1">
                                    <path d="m276 318v-167h-39.4v167c-22.9 8.13-39.4 30-39.4 55.7 0 32.6 26.5 59.1 59.1 59.1s59.1-26.5 59.1-59.1c.001-25.7-16.5-47.6-39.4-55.7zm-19.7 75.4c-10.9 0-19.7-8.83-19.7-19.7s8.83-19.7 19.7-19.7 19.7 8.83 19.7 19.7-8.83 19.7-19.7 19.7z" style="stroke-width:24.1"/>
                                    <path d="m354 278v-179c0-54.3-44.2-98.5-98.5-98.5s-98.5 44.2-98.5 98.5v179c-25.1 25.7-39.4 60.3-39.4 96.5.001 76 61.8 138 138 138s138-61.8 138-138c0-36.1-14.3-70.8-39.4-96.5zm-98.5 195c-54.3 0-98.5-44.2-98.5-98.5 0-28 12-54.7 32.8-73.4l6.56-5.87v-196c0-32.6 26.5-59.1 59.1-59.1s59.1 26.5 59.1 59.1v196l6.56 5.87c20.9 18.7 32.8 45.4 32.8 73.4 0 54.3-44.2 98.5-98.5 98.5z" style="stroke-width:24.1"/>
                                 </g>
                              </g>
                           </g>
                           <path d="m43.7 71.3c-1.93 0-3.5 1.57-3.5 3.5 0 1.59 1.06 2.93 2.51 3.36v.912c0 .129.105.234.234.234h1.51c.129 0 .234-.105.234-.234v-.912c1.45-.427 2.51-1.77 2.51-3.36-1.6e-5-1.93-1.57-3.5-3.5-3.5zm.519 7.53h-1.04v-.574c.343.051.695.051 1.04 0zm-.519-1c-1.67 0-3.03-1.36-3.03-3.03 0-1.67 1.36-3.03 3.03-3.03s3.03 1.36 3.03 3.03c0 1.67-1.36 3.03-3.03 3.03z" style="stroke-width:.235"/>
                        </g>
                     </g>
                     <text x="328.36539" y="46.8834" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="328.36539" y="46.8834">{{ plc.ch1LowOutletTemp.toFixed(1) }} °C</tspan></text>
                     <text x="297.59531" y="11.716424" style="fill:#ff0000;font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="297.59531" y="11.716424">{{ plc.ch1HeatCurveTemp.toFixed(1) }} °C</tspan></text>
                     <g transform="matrix(1.01 0 0 1.01 348 13.4)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.01 0 0 1.01 401 13.4)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(.17 0 0 .171 468 22.8)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <rect x="270" y="30.9" width="236" height="2" style="fill:#c80000;stroke-width:.368"/>
                     <g transform="matrix(.17 0 0 .171 468 49.4)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <g transform="matrix(1.01 0 0 1.01 348 40)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.5 0 0 1.49 310 -66.9)" style="stroke-width:.779">
                        <rect x="69.1" y="74.5" width="5.35" height="8.2" ry="1.56" style="fill:none;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.362;stroke:#000"/>
                        <path d="m69.1 78.6 5.31-.1" style="fill:none;stroke-width:.284;stroke:#000"/>
                        <rect x="71.2" y="82.8" width="1.17" height=".797" ry="0" style="fill:none;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.206;stroke:#000"/>
                     </g>
                     <rect x="270" y="57.8" width="236" height="2" style="fill:#1300e3;stroke-width:.368"/>
                     <g transform="matrix(1.01 0 0 1.01 33.3 13.1)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <text x="20.041454" y="45.917336" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="20.041454" y="45.917336" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265">{{ t('components.climatix.network') }}</tspan></text>
                     <g transform="matrix(1.01 0 0 1.01 65.5 13.1)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(.0176 0 0 .0176 111 22.4)" style="stroke-width:15.1">
                        <path d="m256 64.3c-88 0-160 71.6-160 160s71.6 160 160 160 160-71.6 160-160-71.6-160-160-160zm102 240-5.76-5.76c-5.86-5.86-15.4-5.86-21.2-.005-5.86 5.86-5.86 15.4-.005 21.2l5.76 5.77c-22.1 17.5-50 28-80.4 28s-58.3-10.5-80.4-28l5.76-5.77c5.86-5.86 5.85-15.4-.005-21.2s-15.4-5.85-21.2.005l-5.76 5.76c-14.6-18.4-24.3-40.9-27.1-65.4h8.23c8.28 0 15-6.72 15-15s-6.72-15-15-15h-8.23c2.84-24.5 12.5-47 27.1-65.4l5.76 5.76c5.86 5.86 15.4 5.86 21.2.005 5.86-5.86 5.86-15.4.005-21.2l-5.76-5.77c18.4-14.6 40.9-24.3 65.4-27.1v8.23c0 8.28 6.72 15 15 15s15-6.72 15-15v-8.23c24.5 2.84 47 12.5 65.4 27.1l-5.76 5.77c-5.86 5.86-5.85 15.4.005 21.2 5.86 5.86 15.4 5.85 21.2-.005l5.76-5.76c14.6 18.4 24.3 40.9 27.1 65.4h-8.23c-8.28 0-15 6.72-15 15s6.72 15 15 15h8.23c-2.84 24.5-12.5 47-27.1 65.4z" style="stroke-width:15.1"/>
                        <path d="m261 197-56.2 56.2c-5.86 5.86-5.86 15.4 0 21.2 5.86 5.86 15.4 5.86 21.2 0l56.2-56.2c5.86-5.86 5.86-15.4 0-21.2-5.86-5.86-15.4-5.86-21.2 0z" style="stroke-width:15.1"/>
                        <path d="m256 0c-123 0-224 100-224 224 0 102 67.9 187 161 215v58.4c0 8.28 6.72 15 15 15h96.4c8.28 0 15-6.72 15-15v-58.4c92.8-27.3 161-113 161-215-.001-123-100-224-224-224zm33.2 482h-66.4v-36.7c21.9 3.27 44.5 3.27 66.4 0zm-33.2-64.3c-107 0-194-87-194-194s87-194 194-194 194 87 194 194-87 194-194 194z" style="stroke-width:15.1"/>
                     </g>
                     <rect x="26.1" y="30.9" width="221" height="2" style="fill:#e70000;stroke-width:.341"/>
                     <path d="m19.5 30v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <g transform="matrix(1.01 0 0 1.01 33 40.3)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(.0176 0 0 .0176 111 49.4)" style="stroke-width:15.1">
                        <path d="m256 64.3c-88 0-160 71.6-160 160s71.6 160 160 160 160-71.6 160-160-71.6-160-160-160zm102 240-5.76-5.76c-5.86-5.86-15.4-5.86-21.2-.005-5.86 5.86-5.86 15.4-.005 21.2l5.76 5.77c-22.1 17.5-50 28-80.4 28s-58.3-10.5-80.4-28l5.76-5.77c5.86-5.86 5.85-15.4-.005-21.2s-15.4-5.85-21.2.005l-5.76 5.76c-14.6-18.4-24.3-40.9-27.1-65.4h8.23c8.28 0 15-6.72 15-15s-6.72-15-15-15h-8.23c2.84-24.5 12.5-47 27.1-65.4l5.76 5.76c5.86 5.86 15.4 5.86 21.2.005 5.86-5.86 5.86-15.4.005-21.2l-5.76-5.77c18.4-14.6 40.9-24.3 65.4-27.1v8.23c0 8.28 6.72 15 15 15s15-6.72 15-15v-8.23c24.5 2.84 47 12.5 65.4 27.1l-5.76 5.77c-5.86 5.86-5.85 15.4.005 21.2 5.86 5.86 15.4 5.85 21.2-.005l5.76-5.76c14.6 18.4 24.3 40.9 27.1 65.4h-8.23c-8.28 0-15 6.72-15 15s6.72 15 15 15h8.23c-2.84 24.5-12.5 47-27.1 65.4z" style="stroke-width:15.1"/>
                        <path d="m261 197-56.2 56.2c-5.86 5.86-5.86 15.4 0 21.2 5.86 5.86 15.4 5.86 21.2 0l56.2-56.2c5.86-5.86 5.86-15.4 0-21.2-5.86-5.86-15.4-5.86-21.2 0z" style="stroke-width:15.1"/>
                        <path d="m256 0c-123 0-224 100-224 224 0 102 67.9 187 161 215v58.4c0 8.28 6.72 15 15 15h96.4c8.28 0 15-6.72 15-15v-58.4c92.8-27.3 161-113 161-215-.001-123-100-224-224-224zm33.2 482h-66.4v-36.7c21.9 3.27 44.5 3.27 66.4 0zm-33.2-64.3c-107 0-194-87-194-194s87-194 194-194 194 87 194 194-87 194-194 194z" style="stroke-width:15.1"/>
                     </g>
                     <g transform="matrix(.0176 0 0 .0176 293 49.2)" style="stroke-width:15.1">
                        <path d="m256 64.3c-88 0-160 71.6-160 160s71.6 160 160 160 160-71.6 160-160-71.6-160-160-160zm102 240-5.76-5.76c-5.86-5.86-15.4-5.86-21.2-.005-5.86 5.86-5.86 15.4-.005 21.2l5.76 5.77c-22.1 17.5-50 28-80.4 28s-58.3-10.5-80.4-28l5.76-5.77c5.86-5.86 5.85-15.4-.005-21.2s-15.4-5.85-21.2.005l-5.76 5.76c-14.6-18.4-24.3-40.9-27.1-65.4h8.23c8.28 0 15-6.72 15-15s-6.72-15-15-15h-8.23c2.84-24.5 12.5-47 27.1-65.4l5.76 5.76c5.86 5.86 15.4 5.86 21.2.005 5.86-5.86 5.86-15.4.005-21.2l-5.76-5.77c18.4-14.6 40.9-24.3 65.4-27.1v8.23c0 8.28 6.72 15 15 15s15-6.72 15-15v-8.23c24.5 2.84 47 12.5 65.4 27.1l-5.76 5.77c-5.86 5.86-5.85 15.4.005 21.2 5.86 5.86 15.4 5.85 21.2-.005l5.76-5.76c14.6 18.4 24.3 40.9 27.1 65.4h-8.23c-8.28 0-15 6.72-15 15s6.72 15 15 15h8.23c-2.84 24.5-12.5 47-27.1 65.4z" style="stroke-width:15.1"/>
                        <path d="m261 197-56.2 56.2c-5.86 5.86-5.86 15.4 0 21.2 5.86 5.86 15.4 5.86 21.2 0l56.2-56.2c5.86-5.86 5.86-15.4 0-21.2-5.86-5.86-15.4-5.86-21.2 0z" style="stroke-width:15.1"/>
                        <path d="m256 0c-123 0-224 100-224 224 0 102 67.9 187 161 215v58.4c0 8.28 6.72 15 15 15h96.4c8.28 0 15-6.72 15-15v-58.4c92.8-27.3 161-113 161-215-.001-123-100-224-224-224zm33.2 482h-66.4v-36.7c21.9 3.27 44.5 3.27 66.4 0zm-33.2-64.3c-107 0-194-87-194-194s87-194 194-194 194 87 194 194-87 194-194 194z" style="stroke-width:15.1"/>
                     </g>
                     <rect x="26.3" y="57.8" width="221" height="2" style="fill:#450097;stroke-width:.34"/>
                     <path d="m19.6 57v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <g transform="matrix(1.01 0 0 1.01 65.3 40.3)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <circle cx="313" cy="28.3" r="0" style="fill:#fff;stroke-width:.074;stroke:#000"/>
                     <g transform="translate(172 13.4)">
                        <ellipse cx="219" cy="18.7" rx="5.85" ry="5.85" :fill="getPumpStatus(plc.ch2PumpAlarm, plc.ch2PumpStatus)" style="stroke-width:.3;stroke:#000"/>
                        <path d="m217 24.1 7.92-4.09" style="fill:none;stroke-width:.3;stroke:#000"/>
                        <path d="m217 13.2 7.92 4.09" style="fill-rule:evenodd;stroke-width:.3;stroke:#000"/>
                     </g>
                     <path d="m505 30.1v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <path d="m505 57v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <text x="513.12549" y="47.578751" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="513.12549" y="47.578751" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">{{ t('components.climatix.ch') }}</tspan></text>
                     <g transform="translate(.113 58)">
                        <g transform="matrix(1.12 0 0 1.12 249 -60.9)" style="stroke-width:.889">
                           <g transform="matrix(.00977 0 0 .00977 41.2 72.3)" style="stroke-width:24.1">
                              <g style="stroke-width:24.1">
                                 <g style="stroke-width:24.1">
                                    <path d="m276 318v-167h-39.4v167c-22.9 8.13-39.4 30-39.4 55.7 0 32.6 26.5 59.1 59.1 59.1s59.1-26.5 59.1-59.1c.001-25.7-16.5-47.6-39.4-55.7zm-19.7 75.4c-10.9 0-19.7-8.83-19.7-19.7s8.83-19.7 19.7-19.7 19.7 8.83 19.7 19.7-8.83 19.7-19.7 19.7z" style="stroke-width:24.1"/>
                                    <path d="m354 278v-179c0-54.3-44.2-98.5-98.5-98.5s-98.5 44.2-98.5 98.5v179c-25.1 25.7-39.4 60.3-39.4 96.5.001 76 61.8 138 138 138s138-61.8 138-138c0-36.1-14.3-70.8-39.4-96.5zm-98.5 195c-54.3 0-98.5-44.2-98.5-98.5 0-28 12-54.7 32.8-73.4l6.56-5.87v-196c0-32.6 26.5-59.1 59.1-59.1s59.1 26.5 59.1 59.1v196l6.56 5.87c20.9 18.7 32.8 45.4 32.8 73.4 0 54.3-44.2 98.5-98.5 98.5z" style="stroke-width:24.1"/>
                                 </g>
                              </g>
                           </g>
                           <path d="m43.7 71.3c-1.93 0-3.5 1.57-3.5 3.5 0 1.59 1.06 2.93 2.51 3.36v.912c0 .129.105.234.234.234h1.51c.129 0 .234-.105.234-.234v-.912c1.45-.427 2.51-1.77 2.51-3.36-1.6e-5-1.93-1.57-3.5-3.5-3.5zm.519 7.53h-1.04v-.574c.343.051.695.051 1.04 0zm-.519-1c-1.67 0-3.03-1.36-3.03-3.03 0-1.67 1.36-3.03 3.03-3.03s3.03 1.36 3.03 3.03c0 1.67-1.36 3.03-3.03 3.03z" style="stroke-width:.235"/>
                        </g>
                     </g>
                     <g transform="translate(30.9 85)">
                        <g transform="matrix(1.12 0 0 1.12 249 -60.9)" style="stroke-width:.889">
                           <g transform="matrix(.00977 0 0 .00977 41.2 72.3)" style="stroke-width:24.1">
                              <g style="stroke-width:24.1">
                                 <g style="stroke-width:24.1">
                                    <path d="m276 318v-167h-39.4v167c-22.9 8.13-39.4 30-39.4 55.7 0 32.6 26.5 59.1 59.1 59.1s59.1-26.5 59.1-59.1c.001-25.7-16.5-47.6-39.4-55.7zm-19.7 75.4c-10.9 0-19.7-8.83-19.7-19.7s8.83-19.7 19.7-19.7 19.7 8.83 19.7 19.7-8.83 19.7-19.7 19.7z" style="stroke-width:24.1"/>
                                    <path d="m354 278v-179c0-54.3-44.2-98.5-98.5-98.5s-98.5 44.2-98.5 98.5v179c-25.1 25.7-39.4 60.3-39.4 96.5.001 76 61.8 138 138 138s138-61.8 138-138c0-36.1-14.3-70.8-39.4-96.5zm-98.5 195c-54.3 0-98.5-44.2-98.5-98.5 0-28 12-54.7 32.8-73.4l6.56-5.87v-196c0-32.6 26.5-59.1 59.1-59.1s59.1 26.5 59.1 59.1v196l6.56 5.87c20.9 18.7 32.8 45.4 32.8 73.4 0 54.3-44.2 98.5-98.5 98.5z" style="stroke-width:24.1"/>
                                 </g>
                              </g>
                           </g>
                           <path d="m43.7 71.3c-1.93 0-3.5 1.57-3.5 3.5 0 1.59 1.06 2.93 2.51 3.36v.912c0 .129.105.234.234.234h1.51c.129 0 .234-.105.234-.234v-.912c1.45-.427 2.51-1.77 2.51-3.36-1.6e-5-1.93-1.57-3.5-3.5-3.5zm.519 7.53h-1.04v-.574c.343.051.695.051 1.04 0zm-.519-1c-1.67 0-3.03-1.36-3.03-3.03 0-1.67 1.36-3.03 3.03-3.03s3.03 1.36 3.03 3.03c0 1.67-1.36 3.03-3.03 3.03z" style="stroke-width:.235"/>
                        </g>
                     </g>
                     <text x="328.62939" y="101.66486" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="328.62939" y="101.66486">{{ plc.ch2LowOutletTemp.toFixed(1) }} °C</tspan></text>
                     <g transform="matrix(1.01 0 0 1.01 349 68.1)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.01 0 0 1.01 401 68.1)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(.17 0 0 .171 468 77.6)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <rect x="271" y="85.7" width="236" height="2" style="fill:#c80000;stroke-width:.368"/>
                     <g transform="matrix(.17 0 0 .171 468 104)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <g transform="matrix(1.01 0 0 1.01 349 94.8)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.5 0 0 1.49 311 -12.2)" style="stroke-width:.779">
                        <rect x="69.1" y="74.5" width="5.35" height="8.2" ry="1.56" style="fill:none;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.362;stroke:#000"/>
                        <path d="m69.1 78.6 5.31-.1" style="fill:none;stroke-width:.284;stroke:#000"/>
                        <rect x="71.2" y="82.8" width="1.17" height=".797" ry="0" style="fill:none;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.206;stroke:#000"/>
                     </g>
                     <rect x="270" y="113" width="236" height="2" style="fill:#1300e3;stroke-width:.368"/>
                     <g transform="matrix(.0176 0 0 .0176 294 104)" style="stroke-width:15.1">
                        <path d="m256 64.3c-88 0-160 71.6-160 160s71.6 160 160 160 160-71.6 160-160-71.6-160-160-160zm102 240-5.76-5.76c-5.86-5.86-15.4-5.86-21.2-.005-5.86 5.86-5.86 15.4-.005 21.2l5.76 5.77c-22.1 17.5-50 28-80.4 28s-58.3-10.5-80.4-28l5.76-5.77c5.86-5.86 5.85-15.4-.005-21.2s-15.4-5.85-21.2.005l-5.76 5.76c-14.6-18.4-24.3-40.9-27.1-65.4h8.23c8.28 0 15-6.72 15-15s-6.72-15-15-15h-8.23c2.84-24.5 12.5-47 27.1-65.4l5.76 5.76c5.86 5.86 15.4 5.86 21.2.005 5.86-5.86 5.86-15.4.005-21.2l-5.76-5.77c18.4-14.6 40.9-24.3 65.4-27.1v8.23c0 8.28 6.72 15 15 15s15-6.72 15-15v-8.23c24.5 2.84 47 12.5 65.4 27.1l-5.76 5.77c-5.86 5.86-5.85 15.4.005 21.2 5.86 5.86 15.4 5.85 21.2-.005l5.76-5.76c14.6 18.4 24.3 40.9 27.1 65.4h-8.23c-8.28 0-15 6.72-15 15s6.72 15 15 15h8.23c-2.84 24.5-12.5 47-27.1 65.4z" style="stroke-width:15.1"/>
                        <path d="m261 197-56.2 56.2c-5.86 5.86-5.86 15.4 0 21.2 5.86 5.86 15.4 5.86 21.2 0l56.2-56.2c5.86-5.86 5.86-15.4 0-21.2-5.86-5.86-15.4-5.86-21.2 0z" style="stroke-width:15.1"/>
                        <path d="m256 0c-123 0-224 100-224 224 0 102 67.9 187 161 215v58.4c0 8.28 6.72 15 15 15h96.4c8.28 0 15-6.72 15-15v-58.4c92.8-27.3 161-113 161-215-.001-123-100-224-224-224zm33.2 482h-66.4v-36.7c21.9 3.27 44.5 3.27 66.4 0zm-33.2-64.3c-107 0-194-87-194-194s87-194 194-194 194 87 194 194-87 194-194 194z" style="stroke-width:15.1"/>
                     </g>
                     <g transform="translate(172 68.2)">
                        <ellipse cx="219" cy="18.7" rx="5.85" ry="5.85" :fill="getPumpStatus(plc.ch2PumpAlarm, plc.ch2PumpStatus)" style="stroke-width:.3;stroke:#000"/>
                        <path d="m217 24.1 7.92-4.09" style="fill:none;stroke-width:.3;stroke:#000"/>
                        <path d="m217 13.2 7.92 4.09" style="fill-rule:evenodd;stroke-width:.3;stroke:#000"/>
                     </g>
                     <path d="m506 84.9v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <path d="m506 112v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <text x="513.38947" y="102.36028" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="513.38947" y="102.36028" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">{{ t('components.climatix.ch') }}</tspan></text>
                     <g transform="matrix(1.33 0 0 1.33 104 -80.3)" style="stroke-width:.753">
                        <rect x="66.6" y="102" width="11.2" height="5.65" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path d="m66.6 102v5.58l11.1-5.58v5.58z" fill="none" stroke="#000" style="fill:#ffa400;stroke-width:.199"/>
                        <path d="m72.1 105c0-4.78-.0668-4.86-.0668-4.86" style="fill:none;stroke-width:.199px;stroke:#000"/>
                        <circle cx="72.1" cy="97.2" r="2.87" style="fill:#a7a7a7;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.35;stroke:#000"/>
                     </g>
                     <rect transform="rotate(90)" x="31.5" y="-149" width="56.4" height="2" style="fill:#e70000;stroke-width:.282"/>
                     <rect transform="rotate(90)" x="59.2" y="-134" width="52.8" height="2" style="fill:#450097;stroke-width:.276"/>
                     <g transform="matrix(1.13 0 0 .986 67.7 -22.8)" style="stroke-width:1.07">
                        <rect x="86.7" y="53.7" width="7.28" height="3.57" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path d="m86.7 53.7v3.57l7.28-3.57v3.57z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.283"/>
                     </g>
                     <g transform="matrix(1.13 0 0 .986 67.7 4.05)" style="stroke-width:1.07">
                        <rect x="86.7" y="53.7" width="7.28" height="3.57" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path d="m86.7 53.7v3.57l7.28-3.57v3.57z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.283"/>
                     </g>
                     <rect x="148" y="85.9" width="99.8" height="2" style="fill:#e70000;stroke-width:.312"/>
                     <rect x="133" y="110" width="114" height="2" style="fill:#450097;stroke-width:.304"/>
                     <g transform="matrix(1.33 0 0 1.33 104 -28.3)" style="stroke-width:.753">
                        <rect x="66.6" y="102" width="11.2" height="5.65" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path d="m66.6 102v5.58l11.1-5.58v5.58z" fill="none" stroke="#000" style="fill:#ffa400;stroke-width:.199"/>
                        <path d="m72.1 105c0-4.78-.0668-4.86-.0668-4.86" style="fill:none;stroke-width:.199px;stroke:#000"/>
                        <circle cx="72.1" cy="97.2" r="2.87" style="fill:#a7a7a7;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.35;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.13 0 0 .986 67.7 32.2)" style="stroke-width:1.07">
                        <rect x="86.7" y="53.7" width="7.28" height="3.57" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path d="m86.7 53.7v3.57l7.28-3.57v3.57z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.283"/>
                     </g>
                     <g transform="matrix(1.13 0 0 .986 67.7 56.2)" style="stroke-width:1.07">
                        <rect x="86.7" y="53.7" width="7.28" height="3.57" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path d="m86.7 53.7v3.57l7.28-3.57v3.57z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.283"/>
                     </g>
                     <rect x="246" y="79.1" width="25.3" height="44.5" ry="4.31" style="fill:url(#c);stroke-width:.266"/>
                     <text x="258.01889" y="103.85229" style="font-family:sans-serif;font-size:7.06px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="258.01889" y="103.85229" style="fill:#ffffff;font-family:sans-serif;font-size:7.06px;font-weight:bold;stroke-width:.265;text-align:center;text-anchor:middle" :visibility="getSectionStatus(plc.ch2Status)">{{ t('components.climatix.ch2Short') }}</tspan></text>
                     <rect x="246" y="24.5" width="25.3" height="44.5" ry="4.31" style="fill:url(#e);stroke-width:.266"/>
                     <text x="258.54254" y="48.733189" style="font-family:sans-serif;font-size:7.06px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="258.54254" y="48.733189" style="fill:#ffffff;font-family:sans-serif;font-size:7.06px;font-weight:bold;stroke-width:.265;text-align:center;text-anchor:middle" :visibility="getSectionStatus(plc.ch1Status)">{{ t('components.climatix.ch1Short') }}</tspan></text>
                     <text x="115.39965" y="20.126001" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="115.39965" y="20.126001">{{ plc.chHighInletPresure.toFixed(1) }} Bar</tspan></text>
                     <text x="115.11905" y="47.033669" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="115.11905" y="47.033669">{{ plc.chHighOutletPresure.toFixed(1) }} Bar</tspan></text>
                     <text transform="translate(-74.5 64.9)" x="568.32159" y="-47.113564" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;inline-size:133.935;line-height:1.25;stroke-width:.265;text-align:end;text-anchor:end;white-space:pre" xml:space="preserve"><tspan x="568.32159" y="-47.113564">{{ plc.outsideTemp.toFixed(1) }} °C</tspan></text>
                     <path d="m509 19.8c0 .355-.288.643-.643.643-.355 0-.643-.288-.643-.643 0-.355.288-.643.643-.643.355 0 .643.288.643.643zm2.38-3.6h1.58v-1.29h-1.58zm0-3.54v1.29h1.58v-1.29zm0 5.79h1.58v-1.29h-1.58zm-.965-.731c.548.559.868 1.32.868 2.08 0 1.63-1.33 2.96-2.96 2.96s-2.96-1.33-2.96-2.96c0-.764.319-1.52.866-2.08l.002-3.93c0-1.15.938-2.09 2.09-2.09 1.15 0 2.09.938 2.09 2.09zm-.418 2.08c0-.489-.237-.977-.635-1.3l-.234-.193v-4.52c0-.443-.361-.804-.804-.804-.443 0-.804.361-.804.804l-.002 4.52-.233.193c-.396.328-.633.815-.633 1.3 0 .922.75 1.67 1.67 1.67.922 0 1.67-.75 1.67-1.67zm-5.95 1.67h-4.02c-.355 0-.643-.289-.643-.643v-7.93l5.34-4.87 2.61 2.38h1.91l-4.51-4.12-8.24 7.52.867.95.749-.683v6.75c0 1.06.865 1.93 1.93 1.93h5.26c-.36-.37-.653-.805-.86-1.29z" fill="url(#a)" style="fill:url(#d);stroke-width:.0549"/>
                  </g>
               </svg>
               <!-- graphic heating domestic -->
               <!-- prettier-ignore -->
               <svg
                  v-if="isDomesticPlcType(plc)"
                  class="d-none d-lg-block"
                  version="1.1"
                  viewBox="0 0 501 138"
                  xmlns="http://www.w3.org/2000/svg"
                  xmlns:xlink="http://www.w3.org/1999/xlink"
               >
                  <defs id="defs2">
                     <linearGradient id="linearGradient2997">
                        <stop id="stop2991" style="stop-color:#00f" offset="0"/>
                        <stop id="stop2993" style="stop-color:#a00" offset=".584"/>
                        <stop id="stop2995" style="stop-color:#f00" offset="1"/>
                     </linearGradient>
                     <linearGradient id="a" x1="256" x2="256" y1="9.98e-5" y2="512" gradientTransform="matrix(.0387 0 0 .0387 17.2 154)" gradientUnits="userSpaceOnUse">
                        <stop id="stop2" stop-color="#2af598" offset="0"/>
                        <stop id="stop4" stop-color="#009efd" offset="1"/>
                     </linearGradient>
                     <linearGradient id="linearGradient664" x1="221" x2="196" y1="151" y2="97.7" gradientTransform="matrix(.98 0 0 .835 54.2 -2.5)" gradientUnits="userSpaceOnUse" xlink:href="#linearGradient2997"/>
                     <linearGradient id="linearGradient1584" x1="221" x2="196" y1="151" y2="97.7" gradientTransform="matrix(.98 0 0 .835 54.2 -57)" gradientUnits="userSpaceOnUse" xlink:href="#linearGradient2997"/>
                     <linearGradient id="linearGradient328" x1="256" x2="256" y1="9.98e-5" y2="512" gradientTransform="matrix(.0322 0 0 .0322 496 6.28)" gradientUnits="userSpaceOnUse" xlink:href="#a"/>
                  </defs>
                  <g id="layer1" transform="translate(-16.6 -4.25)">
                     <text id="text4258-4-5-8-7" x="199.94214" y="94.78157" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan id="tspan2261">{{ plc.dhwValvePosition.toFixed(1) }} %</tspan></text>
                     <text id="text4258-4-5-8-7-0" x="200.04912" y="42.26754" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan id="tspan2261-8" x="200.04912" y="42.26754">{{ plc.ch1ValvePosition.toFixed(1) }} %</tspan></text>
                     <g id="g1868" transform="translate(-.382 -2.12)">
                        <g id="g3632-6-1" transform="matrix(1.12 0 0 1.12 249 -.613)" style="stroke-width:.889">
                           <g id="g895-2-8" transform="matrix(.00977 0 0 .00977 41.2 72.3)" style="stroke-width:24.1">
                              <g id="g6-5-9" style="stroke-width:24.1">
                                 <g id="g4-3-3" style="stroke-width:24.1">
                                    <path id="path2-2-9-9" d="m276 318v-167h-39.4v167c-22.9 8.13-39.4 30-39.4 55.7 0 32.6 26.5 59.1 59.1 59.1s59.1-26.5 59.1-59.1c.001-25.7-16.5-47.6-39.4-55.7zm-19.7 75.4c-10.9 0-19.7-8.83-19.7-19.7s8.83-19.7 19.7-19.7 19.7 8.83 19.7 19.7-8.83 19.7-19.7 19.7z" style="stroke-width:24.1"/>
                                 </g>
                              </g>
                              <g id="g12-5-5" style="stroke-width:24.1">
                                 <g id="g10-0-1" style="stroke-width:24.1">
                                    <path id="path8-7-2" d="m354 278v-179c0-54.3-44.2-98.5-98.5-98.5s-98.5 44.2-98.5 98.5v179c-25.1 25.7-39.4 60.3-39.4 96.5.001 76 61.8 138 138 138s138-61.8 138-138c0-36.1-14.3-70.8-39.4-96.5zm-98.5 195c-54.3 0-98.5-44.2-98.5-98.5 0-28 12-54.7 32.8-73.4l6.56-5.87v-196c0-32.6 26.5-59.1 59.1-59.1s59.1 26.5 59.1 59.1v196l6.56 5.87c20.9 18.7 32.8 45.4 32.8 73.4 0 54.3-44.2 98.5-98.5 98.5z" style="stroke-width:24.1"/>
                                 </g>
                              </g>
                           </g>
                           <path id="path6-8-1-2-7" d="m43.7 71.3c-1.93 0-3.5 1.57-3.5 3.5 0 1.59 1.06 2.93 2.51 3.36v.912c0 .129.105.234.234.234h1.51c.129 0 .234-.105.234-.234v-.912c1.45-.427 2.51-1.77 2.51-3.36-1.6e-5-1.93-1.57-3.5-3.5-3.5zm.519 7.53h-1.04v-.574c.343.051.695.051 1.04 0zm-.519-1c-1.67 0-3.03-1.36-3.03-3.03 0-1.67 1.36-3.03 3.03-3.03s3.03 1.36 3.03 3.03c0 1.67-1.36 3.03-3.03 3.03z" style="stroke-width:.235"/>
                        </g>
                     </g>
                     <text id="text4258-4-5-8" x="297.73947" y="74.870934" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan id="tspan1139" x="297.73947" y="74.870934">{{ plc.dhwTemp.toFixed(1) }} °C</tspan></text>
                     <text id="text4258-4-5-9-7" x="297.73947" y="67.756256" style="fill:#ff0000;font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan id="tspan1141" x="297.73947" y="67.756256">{{ plc.dhwTempSet.toFixed(1) }} °C</tspan></text>
                     <text id="text4258-6" x="297.72708" y="46.519512" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve">          <tspan id="tspan1142" x="297.72708" y="46.519512">{{ plc.ch1LowOutletPresure.toFixed(1) }} Bar</tspan></text>
                     <g id="g1900" transform="translate(-.15 3.18)">
                        <g id="g3632-6" transform="matrix(1.12 0 0 1.12 249 -60.9)" style="stroke-width:.889">
                           <g id="g895-2" transform="matrix(.00977 0 0 .00977 41.2 72.3)" style="stroke-width:24.1">
                              <g id="g6-5" style="stroke-width:24.1">
                                 <g id="g4-3" style="stroke-width:24.1">
                                    <path id="path2-2-9" d="m276 318v-167h-39.4v167c-22.9 8.13-39.4 30-39.4 55.7 0 32.6 26.5 59.1 59.1 59.1s59.1-26.5 59.1-59.1c.001-25.7-16.5-47.6-39.4-55.7zm-19.7 75.4c-10.9 0-19.7-8.83-19.7-19.7s8.83-19.7 19.7-19.7 19.7 8.83 19.7 19.7-8.83 19.7-19.7 19.7z" style="stroke-width:24.1"/>
                                 </g>
                              </g>
                              <g id="g12-5" style="stroke-width:24.1">
                                 <g id="g10-0" style="stroke-width:24.1">
                                    <path id="path8-7" d="m354 278v-179c0-54.3-44.2-98.5-98.5-98.5s-98.5 44.2-98.5 98.5v179c-25.1 25.7-39.4 60.3-39.4 96.5.001 76 61.8 138 138 138s138-61.8 138-138c0-36.1-14.3-70.8-39.4-96.5zm-98.5 195c-54.3 0-98.5-44.2-98.5-98.5 0-28 12-54.7 32.8-73.4l6.56-5.87v-196c0-32.6 26.5-59.1 59.1-59.1s59.1 26.5 59.1 59.1v196l6.56 5.87c20.9 18.7 32.8 45.4 32.8 73.4 0 54.3-44.2 98.5-98.5 98.5z" style="stroke-width:24.1"/>
                                 </g>
                              </g>
                           </g>
                           <path id="path6-8-1-2" d="m43.7 71.3c-1.93 0-3.5 1.57-3.5 3.5 0 1.59 1.06 2.93 2.51 3.36v.912c0 .129.105.234.234.234h1.51c.129 0 .234-.105.234-.234v-.912c1.45-.427 2.51-1.77 2.51-3.36-1.6e-5-1.93-1.57-3.5-3.5-3.5zm.519 7.53h-1.04v-.574c.343.051.695.051 1.04 0zm-.519-1c-1.67 0-3.03-1.36-3.03-3.03 0-1.67 1.36-3.03 3.03-3.03s3.03 1.36 3.03 3.03c0 1.67-1.36 3.03-3.03 3.03z" style="stroke-width:.235"/>
                        </g>
                     </g>
                     <text id="text4258-4-5" x="297.59531" y="19.889423" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan id="tspan1140" x="297.59531" y="19.889423">{{ plc.ch1LowInletTemp.toFixed(1) }} °C</tspan></text>
                     <g id="g1900-1" transform="translate(30.6 30.2)">
                        <g id="g3632-6-5" transform="matrix(1.12 0 0 1.12 249 -60.9)" style="stroke-width:.889">
                           <g id="g895-2-4" transform="matrix(.00977 0 0 .00977 41.2 72.3)" style="stroke-width:24.1">
                              <g id="g6-5-5" style="stroke-width:24.1">
                                 <g id="g4-3-5" style="stroke-width:24.1">
                                    <path id="path2-2-9-5" d="m276 318v-167h-39.4v167c-22.9 8.13-39.4 30-39.4 55.7 0 32.6 26.5 59.1 59.1 59.1s59.1-26.5 59.1-59.1c.001-25.7-16.5-47.6-39.4-55.7zm-19.7 75.4c-10.9 0-19.7-8.83-19.7-19.7s8.83-19.7 19.7-19.7 19.7 8.83 19.7 19.7-8.83 19.7-19.7 19.7z" style="stroke-width:24.1"/>
                                 </g>
                              </g>
                              <g id="g12-5-3" style="stroke-width:24.1">
                                 <g id="g10-0-9" style="stroke-width:24.1">
                                    <path id="path8-7-1" d="m354 278v-179c0-54.3-44.2-98.5-98.5-98.5s-98.5 44.2-98.5 98.5v179c-25.1 25.7-39.4 60.3-39.4 96.5.001 76 61.8 138 138 138s138-61.8 138-138c0-36.1-14.3-70.8-39.4-96.5zm-98.5 195c-54.3 0-98.5-44.2-98.5-98.5 0-28 12-54.7 32.8-73.4l6.56-5.87v-196c0-32.6 26.5-59.1 59.1-59.1s59.1 26.5 59.1 59.1v196l6.56 5.87c20.9 18.7 32.8 45.4 32.8 73.4 0 54.3-44.2 98.5-98.5 98.5z" style="stroke-width:24.1"/>
                                 </g>
                              </g>
                           </g>
                           <path id="path6-8-1-2-5" d="m43.7 71.3c-1.93 0-3.5 1.57-3.5 3.5 0 1.59 1.06 2.93 2.51 3.36v.912c0 .129.105.234.234.234h1.51c.129 0 .234-.105.234-.234v-.912c1.45-.427 2.51-1.77 2.51-3.36-1.6e-5-1.93-1.57-3.5-3.5-3.5zm.519 7.53h-1.04v-.574c.343.051.695.051 1.04 0zm-.519-1c-1.67 0-3.03-1.36-3.03-3.03 0-1.67 1.36-3.03 3.03-3.03s3.03 1.36 3.03 3.03c0 1.67-1.36 3.03-3.03 3.03z" style="stroke-width:.235"/>
                        </g>
                     </g>
                     <text id="text4258-4-5-2" x="328.36539" y="46.8834" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan id="tspan1140-0" x="328.36539" y="46.8834">{{ plc.ch1LowOutletTemp.toFixed(1) }} °C</tspan></text>
                     <text id="text4258-4-5-9" x="297.59531" y="11.716424" style="fill:#ff0000;font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan id="tspan1143" x="297.59531" y="11.716424">{{ plc.ch1HeatCurveTemp.toFixed(1) }} °C</tspan></text>
                     <g id="g3272-3-1-4" transform="matrix(1.01 0 0 1.01 348 13.4)" style="stroke-width:.989">
                        <path id="path6703-4-0-2-0" d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path6705-4-8-8-9" d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path id="path7580-1-9-7" d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path7582-5-7-3" d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g id="g3272-3-1-4-6" transform="matrix(1.01 0 0 1.01 401 13.4)" style="stroke-width:.989">
                        <path id="path6703-4-0-2-0-8" d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path6705-4-8-8-9-2" d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path id="path7580-1-9-7-4" d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path7582-5-7-3-5" d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g id="g837-4" transform="matrix(.17 0 0 .171 468 22.8)" style="stroke-width:1.66">
                        <path id="path6703-5" d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path id="path6705-1" transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path id="path8463-7" d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path id="path8465-0" transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <rect id="rect2941-51" x="270" y="30.9" width="236" height="2" style="fill:#c80000;stroke-width:.368"/>
                     <g id="g837-4-3" transform="matrix(.17 0 0 .171 468 49.4)" style="stroke-width:1.66">
                        <path id="path6703-5-0" d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path id="path6705-1-9" transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path id="path8463-7-6" d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path id="path8465-0-9" transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <g id="g3272-3-1-4-8" transform="matrix(1.01 0 0 1.01 348 40)" style="stroke-width:.989">
                        <path id="path6703-4-0-2-0-2" d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path6705-4-8-8-9-7" d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path id="path7580-1-9-7-6" d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path7582-5-7-3-9" d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g id="g4218" transform="matrix(1.5 0 0 1.49 310 -66.9)" style="stroke-width:.779">
                        <rect id="rect4199" x="69.1" y="74.5" width="5.35" height="8.2" ry="1.56" style="fill:none;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.362;stroke:#000"/>
                        <path id="path4201" d="m69.1 78.6 5.31-.1" style="fill:none;stroke-width:.284;stroke:#000"/>
                        <rect id="rect4205" x="71.2" y="82.8" width="1.17" height=".797" ry="0" style="fill:none;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.206;stroke:#000"/>
                     </g>
                     <rect id="rect2941-5-6" x="270" y="57.8" width="236" height="2" style="fill:#1300e3;stroke-width:.368"/>
                     <g id="g3272" transform="matrix(1.01 0 0 1.01 33.3 13.1)" style="stroke-width:.989">
                        <path id="path6703-4" d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path6705-4" d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path id="path7580" d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path7582" d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <text id="text3139" x="20.041454" y="45.917336" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan id="tspan3137" x="20.041454" y="45.917336" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265">{{ t('components.climatix.network') }}</tspan></text>
                     <g id="g3272-3-1" transform="matrix(1.01 0 0 1.01 65.5 13.1)" style="stroke-width:.989">
                        <path id="path6703-4-0-2" d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path6705-4-8-8" d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path id="path7580-1-9" d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path7582-5-7" d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g id="g8" transform="matrix(.0176 0 0 .0176 111 22.4)" style="stroke-width:15.1">
                        <path id="path2-1" d="m256 64.3c-88 0-160 71.6-160 160s71.6 160 160 160 160-71.6 160-160-71.6-160-160-160zm102 240-5.76-5.76c-5.86-5.86-15.4-5.86-21.2-.005-5.86 5.86-5.86 15.4-.005 21.2l5.76 5.77c-22.1 17.5-50 28-80.4 28s-58.3-10.5-80.4-28l5.76-5.77c5.86-5.86 5.85-15.4-.005-21.2s-15.4-5.85-21.2.005l-5.76 5.76c-14.6-18.4-24.3-40.9-27.1-65.4h8.23c8.28 0 15-6.72 15-15s-6.72-15-15-15h-8.23c2.84-24.5 12.5-47 27.1-65.4l5.76 5.76c5.86 5.86 15.4 5.86 21.2.005 5.86-5.86 5.86-15.4.005-21.2l-5.76-5.77c18.4-14.6 40.9-24.3 65.4-27.1v8.23c0 8.28 6.72 15 15 15s15-6.72 15-15v-8.23c24.5 2.84 47 12.5 65.4 27.1l-5.76 5.77c-5.86 5.86-5.85 15.4.005 21.2 5.86 5.86 15.4 5.85 21.2-.005l5.76-5.76c14.6 18.4 24.3 40.9 27.1 65.4h-8.23c-8.28 0-15 6.72-15 15s6.72 15 15 15h8.23c-2.84 24.5-12.5 47-27.1 65.4z" style="stroke-width:15.1"/>
                        <path id="path4" d="m261 197-56.2 56.2c-5.86 5.86-5.86 15.4 0 21.2 5.86 5.86 15.4 5.86 21.2 0l56.2-56.2c5.86-5.86 5.86-15.4 0-21.2-5.86-5.86-15.4-5.86-21.2 0z" style="stroke-width:15.1"/>
                        <g id="g318">
                           <path id="path6" d="m256 0c-123 0-224 100-224 224 0 102 67.9 187 161 215v58.4c0 8.28 6.72 15 15 15h96.4c8.28 0 15-6.72 15-15v-58.4c92.8-27.3 161-113 161-215-.001-123-100-224-224-224zm33.2 482h-66.4v-36.7c21.9 3.27 44.5 3.27 66.4 0zm-33.2-64.3c-107 0-194-87-194-194s87-194 194-194 194 87 194 194-87 194-194 194z" style="stroke-width:15.1"/>
                        </g>
                     </g>
                     <rect id="rect2941" x="26.1" y="30.9" width="221" height="2" style="fill:#e70000;stroke-width:.341"/>
                     <path id="path2-7" d="m19.5 30v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <g id="g3272-1" transform="matrix(1.01 0 0 1.01 33 40.3)" style="stroke-width:.989">
                        <path id="path6703-4-9" d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path6705-4-3" d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path id="path7580-3" d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path7582-6" d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g id="g8-6" transform="matrix(.0176 0 0 .0176 111 49.4)" style="stroke-width:15.1">
                        <path id="path2-1-7" d="m256 64.3c-88 0-160 71.6-160 160s71.6 160 160 160 160-71.6 160-160-71.6-160-160-160zm102 240-5.76-5.76c-5.86-5.86-15.4-5.86-21.2-.005-5.86 5.86-5.86 15.4-.005 21.2l5.76 5.77c-22.1 17.5-50 28-80.4 28s-58.3-10.5-80.4-28l5.76-5.77c5.86-5.86 5.85-15.4-.005-21.2s-15.4-5.85-21.2.005l-5.76 5.76c-14.6-18.4-24.3-40.9-27.1-65.4h8.23c8.28 0 15-6.72 15-15s-6.72-15-15-15h-8.23c2.84-24.5 12.5-47 27.1-65.4l5.76 5.76c5.86 5.86 15.4 5.86 21.2.005 5.86-5.86 5.86-15.4.005-21.2l-5.76-5.77c18.4-14.6 40.9-24.3 65.4-27.1v8.23c0 8.28 6.72 15 15 15s15-6.72 15-15v-8.23c24.5 2.84 47 12.5 65.4 27.1l-5.76 5.77c-5.86 5.86-5.85 15.4.005 21.2 5.86 5.86 15.4 5.85 21.2-.005l5.76-5.76c14.6 18.4 24.3 40.9 27.1 65.4h-8.23c-8.28 0-15 6.72-15 15s6.72 15 15 15h8.23c-2.84 24.5-12.5 47-27.1 65.4z" style="stroke-width:15.1"/>
                        <path id="path4-9" d="m261 197-56.2 56.2c-5.86 5.86-5.86 15.4 0 21.2 5.86 5.86 15.4 5.86 21.2 0l56.2-56.2c5.86-5.86 5.86-15.4 0-21.2-5.86-5.86-15.4-5.86-21.2 0z" style="stroke-width:15.1"/>
                        <path id="path6-8" d="m256 0c-123 0-224 100-224 224 0 102 67.9 187 161 215v58.4c0 8.28 6.72 15 15 15h96.4c8.28 0 15-6.72 15-15v-58.4c92.8-27.3 161-113 161-215-.001-123-100-224-224-224zm33.2 482h-66.4v-36.7c21.9 3.27 44.5 3.27 66.4 0zm-33.2-64.3c-107 0-194-87-194-194s87-194 194-194 194 87 194 194-87 194-194 194z" style="stroke-width:15.1"/>
                     </g>
                     <g id="g8-6-9" transform="matrix(.0176 0 0 .0176 293 49.2)" style="stroke-width:15.1">
                        <path id="path2-1-7-9" d="m256 64.3c-88 0-160 71.6-160 160s71.6 160 160 160 160-71.6 160-160-71.6-160-160-160zm102 240-5.76-5.76c-5.86-5.86-15.4-5.86-21.2-.005-5.86 5.86-5.86 15.4-.005 21.2l5.76 5.77c-22.1 17.5-50 28-80.4 28s-58.3-10.5-80.4-28l5.76-5.77c5.86-5.86 5.85-15.4-.005-21.2s-15.4-5.85-21.2.005l-5.76 5.76c-14.6-18.4-24.3-40.9-27.1-65.4h8.23c8.28 0 15-6.72 15-15s-6.72-15-15-15h-8.23c2.84-24.5 12.5-47 27.1-65.4l5.76 5.76c5.86 5.86 15.4 5.86 21.2.005 5.86-5.86 5.86-15.4.005-21.2l-5.76-5.77c18.4-14.6 40.9-24.3 65.4-27.1v8.23c0 8.28 6.72 15 15 15s15-6.72 15-15v-8.23c24.5 2.84 47 12.5 65.4 27.1l-5.76 5.77c-5.86 5.86-5.85 15.4.005 21.2 5.86 5.86 15.4 5.85 21.2-.005l5.76-5.76c14.6 18.4 24.3 40.9 27.1 65.4h-8.23c-8.28 0-15 6.72-15 15s6.72 15 15 15h8.23c-2.84 24.5-12.5 47-27.1 65.4z" style="stroke-width:15.1"/>
                        <path id="path4-9-3" d="m261 197-56.2 56.2c-5.86 5.86-5.86 15.4 0 21.2 5.86 5.86 15.4 5.86 21.2 0l56.2-56.2c5.86-5.86 5.86-15.4 0-21.2-5.86-5.86-15.4-5.86-21.2 0z" style="stroke-width:15.1"/>
                        <path id="path6-8-9" d="m256 0c-123 0-224 100-224 224 0 102 67.9 187 161 215v58.4c0 8.28 6.72 15 15 15h96.4c8.28 0 15-6.72 15-15v-58.4c92.8-27.3 161-113 161-215-.001-123-100-224-224-224zm33.2 482h-66.4v-36.7c21.9 3.27 44.5 3.27 66.4 0zm-33.2-64.3c-107 0-194-87-194-194s87-194 194-194 194 87 194 194-87 194-194 194z" style="stroke-width:15.1"/>
                     </g>
                     <rect id="rect2941-5" x="26.3" y="57.8" width="221" height="2" style="fill:#450097;stroke-width:.34"/>
                     <path id="path2" d="m19.6 57v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <g id="g3272-3-1-6" transform="matrix(1.01 0 0 1.01 65.3 40.3)" style="stroke-width:.989">
                        <path id="path6703-4-0-2-5" d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path6705-4-8-8-7" d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path id="path7580-1-9-3" d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path7582-5-7-9" d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <circle id="path2787-1" cx="313" cy="28.3" r="0" style="fill:#fff;stroke-width:.074;stroke:#000"/>
                     <g id="CoPumpStatus" transform="translate(172 13.4)">
                        <ellipse id="path2202-9" cx="219" cy="18.7" rx="5.85" ry="5.85" :fill="getPumpStatus(plc.ch1PumpAlarm, plc.ch1PumpStatus)" style="stroke-width:.3;stroke:#000"/>
                        <path id="path2789-3" d="m217 24.1 7.92-4.09" style="fill:none;stroke-width:.3;stroke:#000"/>
                        <path id="path2791-7" d="m217 13.2 7.92 4.09" style="fill-rule:evenodd;stroke-width:.3;stroke:#000"/>
                     </g>
                     <path id="path2-71" d="m505 30.1v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <path id="path2-71-2" d="m505 57v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <text id="text3139-5" x="513.12549" y="47.578751" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan id="tspan317" x="513.12549" y="47.578751" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">{{ t('components.climatix.ch') }}</tspan></text>
                     <g id="g4432" transform="matrix(1.33 0 0 1.33 104 -80.3)" style="stroke-width:.753">
                        <rect id="rect4426" x="66.6" y="102" width="11.2" height="5.65" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path id="path2-3" d="m66.6 102v5.58l11.1-5.58v5.58z" fill="none" stroke="#000" style="fill:#ffa400;stroke-width:.199"/>
                        <path id="path4412" d="m72.1 105c0-4.78-.0668-4.86-.0668-4.86" style="fill:none;stroke-width:.199px;stroke:#000"/>
                        <circle id="path4414" cx="72.1" cy="97.2" r="2.87" style="fill:#a7a7a7;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.35;stroke:#000"/>
                     </g>
                     <rect id="rect2941-6" transform="rotate(90)" x="31.5" y="-149" width="56.4" height="2" style="fill:#e70000;stroke-width:.282"/>
                     <rect id="rect2941-5-2" transform="rotate(90)" x="59.2" y="-134" width="52.8" height="2" style="fill:#450097;stroke-width:.276"/>
                     <g id="g4544" transform="matrix(1.13 0 0 .986 67.7 -22.8)" style="stroke-width:1.07">
                        <rect id="rect4538" x="86.7" y="53.7" width="7.28" height="3.57" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path id="path2-9" d="m86.7 53.7v3.57l7.28-3.57v3.57z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.283"/>
                     </g>
                     <g id="g4544-3" transform="matrix(1.13 0 0 .986 67.7 4.05)" style="stroke-width:1.07">
                        <rect id="rect4538-7" x="86.7" y="53.7" width="7.28" height="3.57" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path id="path2-9-7" d="m86.7 53.7v3.57l7.28-3.57v3.57z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.283"/>
                     </g>
                     <rect id="rect2941-2" x="148" y="85.9" width="99.8" height="2" style="fill:#e70000;stroke-width:.312"/>
                     <rect id="rect2941-5-9" x="133" y="110" width="114" height="2" style="fill:#450097;stroke-width:.304"/>
                     <g id="g4432-1" transform="matrix(1.33 0 0 1.33 104 -28.3)" style="stroke-width:.753">
                        <rect id="rect4426-3" x="66.6" y="102" width="11.2" height="5.65" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path id="path2-3-5" d="m66.6 102v5.58l11.1-5.58v5.58z" fill="none" stroke="#000" style="fill:#ffa400;stroke-width:.199"/>
                        <path id="path4412-5" d="m72.1 105c0-4.78-.0668-4.86-.0668-4.86" style="fill:none;stroke-width:.199px;stroke:#000"/>
                        <circle id="path4414-8" cx="72.1" cy="97.2" r="2.87" style="fill:#a7a7a7;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.35;stroke:#000"/>
                     </g>
                     <g id="g4544-3-5" transform="matrix(1.13 0 0 .986 67.7 32.2)" style="stroke-width:1.07">
                        <rect id="rect4538-7-8" x="86.7" y="53.7" width="7.28" height="3.57" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path id="path2-9-7-2" d="m86.7 53.7v3.57l7.28-3.57v3.57z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.283"/>
                     </g>
                     <g id="g4544-3-50" transform="matrix(1.13 0 0 .986 67.7 56.2)" style="stroke-width:1.07">
                        <rect id="rect4538-7-6" x="86.7" y="53.7" width="7.28" height="3.57" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path id="path2-9-7-6" d="m86.7 53.7v3.57l7.28-3.57v3.57z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.283"/>
                     </g>
                     <g id="g837-4-4" transform="matrix(.17 0 0 .171 467 77.8)" style="stroke-width:1.66">
                        <path id="path6703-5-6" d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path id="path6705-1-6" transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path id="path8463-7-5" d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path id="path8465-0-3" transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <rect id="rect2941-51-7" x="270" y="85.9" width="237" height="2" style="fill:#f1b345;stroke-width:.369"/>
                     <g id="g837-4-3-7" transform="matrix(.17 0 0 .171 467 102)" style="stroke-width:1.66">
                        <path id="path6703-5-0-8" d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path id="path6705-1-9-3" transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path id="path8463-7-6-8" d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path id="path8465-0-9-2" transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <g id="g3272-3-1-4-8-5" transform="matrix(1.01 0 0 1.01 348 92.3)" style="stroke-width:.989">
                        <path id="path6703-4-0-2-0-2-8" d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path6705-4-8-8-9-7-9" d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path id="path7580-1-9-7-6-6" d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path7582-5-7-3-9-9" d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g id="g4218-3" transform="matrix(1.5 0 0 1.49 310 -14.6)" style="stroke-width:.779">
                        <rect id="rect4199-8" x="69.1" y="74.5" width="5.35" height="8.2" ry="1.56" style="fill:none;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.362;stroke:#000"/>
                        <path id="path4201-3" d="m69.1 78.6 5.31-.1" style="fill:none;stroke-width:.284;stroke:#000"/>
                        <rect id="rect4205-3" x="71.2" y="82.8" width="1.17" height=".797" ry="0" style="fill:none;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.206;stroke:#000"/>
                     </g>
                     <rect id="rect2941-5-6-8" x="270" y="110" width="236" height="2" style="fill:#00da31;stroke-width:.369"/>
                     <path id="path2-71-28" d="m505 85.1v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <path id="path2-71-2-1" d="m505 109v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <g id="g3272-3-1-4-8-6-3" transform="matrix(1.01 0 0 1.01 280 92.3)" style="stroke-width:.989">
                        <path id="path6703-4-0-2-0-2-2-2" d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path6705-4-8-8-9-7-7-8" d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path id="path7580-1-9-7-6-2-0" d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path7582-5-7-3-9-2-4" d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <text id="text3139-5-3" x="513.33771" y="75.58313" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan id="tspan4390-7" x="513.33771" y="75.58313" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">{{ t('components.climatix.waterWarm') }}</tspan></text>
                     <text id="text3139-5-3-1" x="513.33771" y="99.83136" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan id="tspan4390-7-6" x="513.33771" y="99.83136" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">{{ t('components.climatix.waterCold') }}</tspan></text>
                     <g id="g3272-3-1-4-1" transform="matrix(1.01 0 0 1.01 348 115)" style="stroke-width:.989">
                        <path id="path6703-4-0-2-0-9" d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path6705-4-8-8-9-8" d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path id="path7580-1-9-7-0" d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path7582-5-7-3-4" d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g id="g3272-3-1-4-6-8" transform="matrix(1.01 0 0 1.01 400 115)" style="stroke-width:.989">
                        <path id="path6703-4-0-2-0-8-3" d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path6705-4-8-8-9-2-8" d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path id="path7580-1-9-7-4-6" d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path id="path7582-5-7-3-5-6" d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g id="g837-4-3-7-7" transform="matrix(.17 0 0 .171 467 125)" style="stroke-width:1.66">
                        <path id="path6703-5-0-8-3" d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path id="path6705-1-9-3-9" transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path id="path8463-7-6-8-4" d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path id="path8465-0-9-2-0" transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <rect id="rect2941-51-7-8" x="279" y="133" width="228" height="2" style="fill:#f1b345;stroke-width:.373"/>
                     <path id="path2-71-2-1-7" d="m505 132v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <text id="text3139-5-3-1-1" x="513.33771" y="122.99466" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan id="tspan4390-7-6-4" x="513.33771" y="122.99466" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">{{ t('components.climatix.circulation') }}</tspan></text>
                     <g id="g4544-3-5-2" transform="matrix(1.13 0 0 .986 224 79.3)" style="stroke-width:1.07">
                        <rect id="rect4538-7-8-1" x="86.7" y="53.7" width="7.28" height="3.57" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path id="path2-9-7-2-8" d="m86.7 53.7v3.57l7.28-3.57v3.57z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.283"/>
                     </g>
                     <g id="DhwPumpStatus" transform="matrix(-1 0 0 1 609 116)" :fill="getPumpStatus(plc.dhwPumpAlarm, plc.dhwPumpStatus)">
                        <ellipse id="path2202-9-2" cx="219" cy="18.7" rx="5.85" ry="5.85" style="stroke-width:.3;stroke:#000"/>
                        <path id="path2789-3-6" d="m217 24.1 7.92-4.09" style="fill-rule:evenodd;stroke-width:.3;stroke:#000"/>
                        <path id="path2791-7-1" d="m217 13.2 7.92 4.09" style="fill-rule:evenodd;stroke-width:.3;stroke:#000"/>
                     </g>
                     <rect id="rect2941-51-7-8-1" transform="rotate(90)" x="112" y="-281" width="22.9" height="2" style="fill:#f1b345;stroke-width:.306"/>
                     <rect id="rect2941-51-7-8-1-7" transform="scale(-1)" x="-281" y="-112" width="11" height="2" style="fill-opacity:.699;fill:#f1b345;stroke-width:.313"/>
                     <rect id="rect654" x="246" y="79.1" width="25.3" height="44.5" ry="4.31" style="fill:url(#linearGradient664);stroke-width:.266"/>
                     <text id="text1539-1" x="258.01889" y="103.85228" style="font-family:sans-serif;font-size:7.06px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan id="tspan1537-8" x="258.01889" y="103.85228" style="fill:#ffffff;font-family:sans-serif;font-size:7.06px;font-weight:bold;stroke-width:.265;text-align:center;text-anchor:middle" :visibility="getSectionStatus(plc.dhwStatus)">{{ t('components.climatix.dhwShort') }}</tspan></text>
                     <rect id="rect654-1" x="246" y="24.5" width="25.3" height="44.5" ry="4.31" style="fill:url(#linearGradient1584);stroke-width:.266"/>
                     <text id="text1539-1-4" x="258.54254" y="48.733189" style="font-family:sans-serif;font-size:7.06px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan id="tspan1537-8-7" x="258.54254" y="48.733189" style="fill:#ffffff;font-family:sans-serif;font-size:7.06px;font-weight:bold;stroke-width:.265;text-align:center;text-anchor:middle" :visibility="getSectionStatus(plc.ch1Status)">{{ t('components.climatix.ch1Short') }}</tspan></text>
                     <text id="text4258-6-9" x="115.39965" y="20.126001" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan id="tspan315" x="115.39965" y="20.126001">{{ plc.chHighInletPresure.toFixed(1) }} Bar</tspan></text>
                     <text id="text4258-6-9-5" x="115.11905" y="47.033669" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan id="tspan315-2" x="115.11905" y="47.033669">{{ plc.chHighOutletPresure.toFixed(1) }} Bar</tspan></text>
                     <g id="g579">
                        <text id="text4258-4-5-87-6" transform="translate(-74.5 64.9)" x="568.32159" y="-47.113564" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;inline-size:133.935;line-height:1.25;stroke-width:.265;text-align:end;text-anchor:end;white-space:pre" xml:space="preserve"><tspan id="tspan1" x="568.32159" y="-47.113564">{{ plc.outsideTemp.toFixed(1) }} °C</tspan></text>
                        <path id="path7" d="m509 19.8c0 .355-.288.643-.643.643-.355 0-.643-.288-.643-.643 0-.355.288-.643.643-.643.355 0 .643.288.643.643zm2.38-3.6h1.58v-1.29h-1.58zm0-3.54v1.29h1.58v-1.29zm0 5.79h1.58v-1.29h-1.58zm-.965-.731c.548.559.868 1.32.868 2.08 0 1.63-1.33 2.96-2.96 2.96s-2.96-1.33-2.96-2.96c0-.764.319-1.52.866-2.08l.002-3.93c0-1.15.938-2.09 2.09-2.09 1.15 0 2.09.938 2.09 2.09zm-.418 2.08c0-.489-.237-.977-.635-1.3l-.234-.193v-4.52c0-.443-.361-.804-.804-.804-.443 0-.804.361-.804.804l-.002 4.52-.233.193c-.396.328-.633.815-.633 1.3 0 .922.75 1.67 1.67 1.67.922 0 1.67-.75 1.67-1.67zm-5.95 1.67h-4.02c-.355 0-.643-.289-.643-.643v-7.93l5.34-4.87 2.61 2.38h1.91l-4.51-4.12-8.24 7.52.867.95.749-.683v6.75c0 1.06.865 1.93 1.93 1.93h5.26c-.36-.37-.653-.805-.86-1.29z" fill="url(#a)" style="fill:url(#linearGradient328);stroke-width:.0549"/>
                     </g>
                  </g>
               </svg>
            </template>
         </Card>
      </div>
   </div>
</template>
