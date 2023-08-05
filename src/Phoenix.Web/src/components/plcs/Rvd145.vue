<script setup lang="ts">
import { PropType } from "vue";
import { useI18n } from "vue-i18n";
import { getDateTimeShortString } from "../../helpers/dateHelper";
import { getPumpStatus, getSectionStatus, isDomesticPlcType, isHeatingPlcType } from "../../helpers/plcHelper";
import { Rvd145Dto } from "../../models/api/plcs/rvds/dto/rvd145Dto";

const props = defineProps({
   data: {
      type: Object as PropType<Array<Rvd145Dto>>,
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
                        <td>{{ t("components.rvd145.outsideTemp") }}</td>
                        <td class="text-end">{{ plc.outsideTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.rvd145.chHighInletPresure") }}</td>
                        <td class="text-end">{{ plc.chHighInletPresure.toFixed(1) }}</td>
                        <td>bar</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.rvd145.ch1HighOutletTemp") }}</td>
                        <td class="text-end">{{ plc.ch1HighOutletTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.rvd145.ch1HeatCurveTemp") }}</td>
                        <td class="text-end">{{ plc.ch1HeatCurveTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.rvd145.ch1LowInletTemp") }}</td>
                        <td class="text-end">{{ plc.ch1LowInletTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr>
                        <td>{{ t("components.rvd145.ch1LowOutletPresure") }}</td>
                        <td class="text-end">{{ plc.ch1LowOutletPresure.toFixed(1) }}</td>
                        <td>bar</td>
                     </tr>
                     <tr v-if="isDomesticPlcType(plc)">
                        <td>{{ t("components.rvd145.dhwTempSet") }}</td>
                        <td class="text-end">{{ plc.dhwTempSet.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr v-if="isDomesticPlcType(plc)">
                        <td>{{ t("components.rvd145.dhwTemp") }}</td>
                        <td class="text-end">{{ plc.dhwTemp.toFixed(1) }}</td>
                        <td>&#8451;</td>
                     </tr>
                     <tr v-if="isDomesticPlcType(plc)">
                        <td>{{ t("components.rvd145.dhwCirculationTemp") }}</td>
                        <td class="text-end">{{ plc.dhwCirculationTemp.toFixed(1) }}</td>
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
                     <g transform="matrix(1.12 0 0 1.12 178 -30.8)" style="stroke-width:.889">
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
                     <text x="227.46773" y="46.372749" style="font-family:sans-serif;font-size:7.06px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="227.46773" y="46.372749">{{ plc.ch1HighOutletTemp.toFixed(1) }} °C</tspan></text>
                     <text x="303.01874" y="46.519512" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve">          <tspan x="303.01874" y="46.519512">{{ plc.ch1LowOutletPresure.toFixed(1) }} Bar</tspan></text>
                     <g transform="translate(5.14 3.18)">
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
                     <text x="302.88696" y="19.889423" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="302.88696" y="19.889423">{{ plc.ch1LowInletTemp.toFixed(1) }} °C</tspan></text>
                     <text x="302.88696" y="11.716424" style="fill:#ff0000;font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="302.88696" y="11.716424">{{ plc.ch1HeatCurveTemp.toFixed(1) }} °C</tspan></text>
                     <g transform="matrix(1.01 0 0 1.01 338 13.4)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.01 0 0 1.01 390 13.4)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(.17 0 0 .171 457 22.8)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <rect x="270" y="30.9" width="236" height="2" style="fill:#c80000;stroke-width:.368"/>
                     <g transform="matrix(.17 0 0 .171 457 49.4)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <g transform="matrix(1.01 0 0 1.01 338 40)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.5 0 0 1.49 300 -66.9)" style="stroke-width:.779">
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
                     <text x="20.041454" y="45.917336" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="20.041454" y="45.917336" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265">{{ t('components.rvd145.network') }}</tspan></text>
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
                     <g transform="matrix(.0176 0 0 .0176 299 49.2)" style="stroke-width:15.1">
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
                     <g transform="translate(161 13.4)">
                        <ellipse cx="219" cy="18.7" rx="5.85" ry="5.85" :fill="getPumpStatus(false, plc.ch1PumpStatus)" style="stroke-width:.3;stroke:#000"/>
                        <path d="m217 24.1 7.92-4.09" style="fill:none;stroke-width:.3;stroke:#000"/>
                        <path d="m217 13.2 7.92 4.09" style="fill-rule:evenodd;stroke-width:.3;stroke:#000"/>
                     </g>
                     <path d="m505 30.1v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <path d="m505 57v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <text x="513.12549" y="47.578751" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="513.12549" y="47.578751" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">{{ t('components.rvd145.ch') }}</tspan></text>
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
                     <g transform="matrix(-1 0 0 1 599 116)" style="fill:#b5b3b2">
                        <ellipse cx="219" cy="18.7" rx="5.85" ry="5.85" style="fill:#b5b3b2;stroke-width:.3;stroke:#000"/>
                        <path d="m217 24.1 7.92-4.09" style="fill-rule:evenodd;fill:#b5b3b2;stroke-width:.3;stroke:#000"/>
                        <path d="m217 13.2 7.92 4.09" style="fill-rule:evenodd;fill:#b5b3b2;stroke-width:.3;stroke:#000"/>
                     </g>
                     <rect x="246" y="24.5" width="25.3" height="44.5" ry="4.31" style="fill:url(#c);stroke-width:.266"/>
                     <text x="252.99077" y="49.327469" style="font-family:sans-serif;font-size:7.06px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="252.99077" y="49.327469" style="fill:#ffffff;font-family:sans-serif;font-size:7.06px;font-weight:bold;stroke-width:.265" :visibility="getSectionStatus(plc.ch1Status)">{{ t('components.rvd145.chShort') }}</tspan></text>
                     <text x="115.39965" y="20.126001" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="115.39965" y="20.126001">{{ plc.chHighInletPresure.toFixed(1) }} Bar</tspan></text>
                     <text transform="translate(-74.5 64.9)" x="568.32159" y="-47.113564" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;inline-size:133.935;line-height:1.25;stroke-width:.265;text-align:end;text-anchor:end;white-space:pre" xml:space="preserve"><tspan x="568.32159" y="-47.113564">{{ plc.outsideTemp.toFixed(1) }} °C</tspan></text>
                     <path d="m509 19.8c0 .355-.288.643-.643.643-.355 0-.643-.288-.643-.643 0-.355.288-.643.643-.643.355 0 .643.288.643.643zm2.38-3.6h1.58v-1.29h-1.58zm0-3.54v1.29h1.58v-1.29zm0 5.79h1.58v-1.29h-1.58zm-.965-.731c.548.559.868 1.32.868 2.08 0 1.63-1.33 2.96-2.96 2.96s-2.96-1.33-2.96-2.96c0-.764.319-1.52.866-2.08l.002-3.93c0-1.15.938-2.09 2.09-2.09 1.15 0 2.09.938 2.09 2.09zm-.418 2.08c0-.489-.237-.977-.635-1.3l-.234-.193v-4.52c0-.443-.361-.804-.804-.804-.443 0-.804.361-.804.804l-.002 4.52-.233.193c-.396.328-.633.815-.633 1.3 0 .922.75 1.67 1.67 1.67.922 0 1.67-.75 1.67-1.67zm-5.95 1.67h-4.02c-.355 0-.643-.289-.643-.643v-7.93l5.34-4.87 2.61 2.38h1.91l-4.51-4.12-8.24 7.52.867.95.749-.683v6.75c0 1.06.865 1.93 1.93 1.93h5.26c-.36-.37-.653-.805-.86-1.29z" fill="url(#a)" style="fill:url(#b);stroke-width:.0549"/>
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
                     <g transform="matrix(1.12 0 0 1.12 178 -30.8)" style="stroke-width:.889">
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
                     <text x="227.46773" y="46.372749" style="font-family:sans-serif;font-size:7.06px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="227.46773" y="46.372749">{{ plc.ch1HighOutletTemp.toFixed(1) }} °C</tspan></text>
                     <g transform="translate(-3.7 -9)">
                        <g transform="matrix(1.12 0 0 1.12 258 53.4)" style="stroke-width:.889">
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
                     <text x="303.03113" y="122.03365" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="303.03113" y="122.03365">{{ plc.dhwCirculationTemp.toFixed(1) }} °C</tspan></text>
                     <g transform="translate(4.91 -2.12)">
                        <g transform="matrix(1.12 0 0 1.12 249 -.613)" style="stroke-width:.889">
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
                     <text x="303.03113" y="74.870934" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="303.03113" y="74.870934">{{ plc.dhwTemp.toFixed(1) }} °C</tspan></text>
                     <text x="303.03113" y="67.756256" style="fill:#ff0000;font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="303.03113" y="67.756256">{{ plc.dhwTempSet.toFixed(1) }} °C</tspan></text>
                     <text x="303.01874" y="46.519512" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve">          <tspan x="303.01874" y="46.519512">{{ plc.ch1LowOutletPresure.toFixed(1) }} Bar</tspan></text>
                     <g transform="translate(5.14 3.18)">
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
                     <text x="302.88696" y="19.889423" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="302.88696" y="19.889423">{{ plc.ch1LowInletTemp.toFixed(1) }} °C</tspan></text>
                     <text x="302.88696" y="11.716424" style="fill:#ff0000;font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="302.88696" y="11.716424">{{ plc.ch1HeatCurveTemp.toFixed(1) }} °C</tspan></text>
                     <g transform="matrix(1.01 0 0 1.01 338 13.4)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.01 0 0 1.01 390 13.4)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(.17 0 0 .171 457 22.8)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <rect x="270" y="30.9" width="236" height="2" style="fill:#c80000;stroke-width:.368"/>
                     <g transform="matrix(.17 0 0 .171 457 49.4)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <g transform="matrix(1.01 0 0 1.01 338 40)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.5 0 0 1.49 300 -66.9)" style="stroke-width:.779">
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
                     <text x="20.041454" y="45.917336" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="20.041454" y="45.917336" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265">{{ t('components.rvd145.network') }}</tspan></text>
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
                     <g transform="matrix(.0176 0 0 .0176 299 49.2)" style="stroke-width:15.1">
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
                     <g transform="translate(161 13.4)">
                        <ellipse :fill="getPumpStatus(false, plc.ch1PumpStatus)" cx="219" cy="18.7" rx="5.85" ry="5.85" style="stroke-width:.3;stroke:#000"/>
                        <path d="m217 24.1 7.92-4.09" style="fill:none;stroke-width:.3;stroke:#000"/>
                        <path d="m217 13.2 7.92 4.09" style="fill-rule:evenodd;stroke-width:.3;stroke:#000"/>
                     </g>
                     <path d="m505 30.1v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <path d="m505 57v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <text x="513.12549" y="47.578751" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="513.12549" y="47.578751" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">{{ t('components.rvd145.ch') }}</tspan></text>
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
                     <g transform="matrix(.17 0 0 .171 457 77.8)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <rect x="270" y="85.9" width="237" height="2" style="fill:#f1b345;stroke-width:.369"/>
                     <g transform="matrix(.17 0 0 .171 457 102)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <g transform="matrix(1.01 0 0 1.01 338 92.3)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.5 0 0 1.49 300 -14.6)" style="stroke-width:.779">
                        <rect x="69.1" y="74.5" width="5.35" height="8.2" ry="1.56" style="fill:none;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.362;stroke:#000"/>
                        <path d="m69.1 78.6 5.31-.1" style="fill:none;stroke-width:.284;stroke:#000"/>
                        <rect x="71.2" y="82.8" width="1.17" height=".797" ry="0" style="fill:none;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.206;stroke:#000"/>
                     </g>
                     <rect x="270" y="110" width="236" height="2" style="fill:#00da31;stroke-width:.369"/>
                     <path d="m505 85.1v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <path d="m505 109v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <g transform="matrix(1.01 0 0 1.01 285 92.3)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <text x="513.33771" y="75.58313" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="513.33771" y="75.58313" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">{{ t('components.rvd145.waterWarm') }}</tspan></text>
                     <text x="513.33771" y="99.83136" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="513.33771" y="99.83136" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">{{ t('components.rvd145.waterCold') }}</tspan></text>
                     <g transform="matrix(1.01 0 0 1.01 338 115)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.01 0 0 1.01 390 115)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(.17 0 0 .171 457 125)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <rect x="279" y="133" width="228" height="2" style="fill:#f1b345;stroke-width:.373"/>
                     <path d="m505 132v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <text x="513.33771" y="122.99466" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="513.33771" y="122.99466" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">{{ t('components.rvd145.circulation') }}</tspan></text>
                     <g transform="matrix(1.13 0 0 .986 224 79.3)" style="stroke-width:1.07">
                        <rect x="86.7" y="53.7" width="7.28" height="3.57" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path d="m86.7 53.7v3.57l7.28-3.57v3.57z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.283"/>
                     </g>
                     <g transform="matrix(-1 0 0 1 599 116)" :fill="getPumpStatus(false, plc.dhwPumpStatus)">
                        <ellipse cx="219" cy="18.7" rx="5.85" ry="5.85" style="stroke-width:.3;stroke:#000"/>
                        <path d="m217 24.1 7.92-4.09" style="fill-rule:evenodd;stroke-width:.3;stroke:#000"/>
                        <path d="m217 13.2 7.92 4.09" style="fill-rule:evenodd;stroke-width:.3;stroke:#000"/>
                     </g>
                     <rect transform="rotate(90)" x="112" y="-281" width="22.9" height="2" style="fill:#f1b345;stroke-width:.306"/>
                     <rect transform="scale(-1)" x="-281" y="-112" width="11" height="2" style="fill-opacity:.699;fill:#f1b345;stroke-width:.313"/>
                     <rect x="246" y="79.1" width="25.3" height="44.5" ry="4.31" style="fill:url(#c);stroke-width:.266"/>
                     <text x="249.25801" y="103.85228" style="font-family:sans-serif;font-size:7.06px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="249.25801" y="103.85228" style="fill:#ffffff;font-family:sans-serif;font-size:7.06px;font-weight:bold;stroke-width:.265" :visibility="getSectionStatus(plc.dhwStatus)">{{ t('components.rvd145.dhwShort') }}</tspan></text>
                     <rect x="246" y="24.5" width="25.3" height="44.5" ry="4.31" style="fill:url(#e);stroke-width:.266"/>
                     <text x="252.99077" y="49.327469" style="font-family:sans-serif;font-size:7.06px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="252.99077" y="49.327469" style="fill:#ffffff;font-family:sans-serif;font-size:7.06px;font-weight:bold;stroke-width:.265" :visibility="getSectionStatus(plc.ch1Status)">{{ t('components.rvd145.chShort') }}</tspan></text>
                     <text x="115.39965" y="20.126001" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="115.39965" y="20.126001">{{ plc.chHighInletPresure.toFixed(1) }} Bar</tspan></text>
                     <text transform="translate(-74.5 64.9)" x="568.32159" y="-47.113564" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;inline-size:133.935;line-height:1.25;stroke-width:.265;text-align:end;text-anchor:end;white-space:pre" xml:space="preserve"><tspan x="568.32159" y="-47.113564">{{ plc.outsideTemp.toFixed(1) }} °C</tspan></text>
                     <path d="m509 19.8c0 .355-.288.643-.643.643-.355 0-.643-.288-.643-.643 0-.355.288-.643.643-.643.355 0 .643.288.643.643zm2.38-3.6h1.58v-1.29h-1.58zm0-3.54v1.29h1.58v-1.29zm0 5.79h1.58v-1.29h-1.58zm-.965-.731c.548.559.868 1.32.868 2.08 0 1.63-1.33 2.96-2.96 2.96s-2.96-1.33-2.96-2.96c0-.764.319-1.52.866-2.08l.002-3.93c0-1.15.938-2.09 2.09-2.09 1.15 0 2.09.938 2.09 2.09zm-.418 2.08c0-.489-.237-.977-.635-1.3l-.234-.193v-4.52c0-.443-.361-.804-.804-.804-.443 0-.804.361-.804.804l-.002 4.52-.233.193c-.396.328-.633.815-.633 1.3 0 .922.75 1.67 1.67 1.67.922 0 1.67-.75 1.67-1.67zm-5.95 1.67h-4.02c-.355 0-.643-.289-.643-.643v-7.93l5.34-4.87 2.61 2.38h1.91l-4.51-4.12-8.24 7.52.867.95.749-.683v6.75c0 1.06.865 1.93 1.93 1.93h5.26c-.36-.37-.653-.805-.86-1.29z" fill="url(#a)" style="fill:url(#d);stroke-width:.0549"/>
                  </g>
               </svg>
            </template>
         </Card>
      </div>
   </div>
</template>
