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
               <svg
                  v-if="isHeatingPlcType(plc)"
                  class="d-none d-lg-block"
                  xmlns="http://www.w3.org/2000/svg"
                  xmlns:xlink="http://www.w3.org/1999/xlink"
                  viewBox="0 0 500.958 67"
                  xmlns:v="https://vecta.io/nano"
               >
                  <svg:style>
                     <![CDATA[.B{stroke:#000}.C{stroke-linejoin:round}.D{stroke-width:.282}.E{fill:none}.F{font-family:sans-serif}.G{stroke-linecap:round}.H{font-size:6.35px}.I{text-anchor:middle}.J{fill-rule:evenodd}.K{fill:#fff}.L{stroke-width:.298}.M{stroke-width:.3}]]>
                  </svg:style>
                  <defs>
                     <linearGradient
                        id="A"
                        gradientTransform="matrix(0.97966102,0,0,0.83492357,54.201374,-57.023478)"
                        x1="221.49"
                        y1="150.94"
                        x2="195.677"
                        y2="97.672"
                        gradientUnits="userSpaceOnUse"
                     >
                        <stop offset="0" stop-color="#00f" />
                        <stop offset=".584" stop-color="#a00" />
                        <stop offset="1" stop-color="red" />
                     </linearGradient>
                     <linearGradient id="B" x1="504.413" y1="6.284" x2="504.413" y2="22.749" gradientUnits="userSpaceOnUse">
                        <stop offset="0" stop-color="#2af598" />
                        <stop offset="1" stop-color="#009efd" />
                     </linearGradient>
                     <path
                        id="C"
                        d="M43.896 75.423v-1.636h-.385v1.636a.58.58 0 0 0-.385.544.58.58 0 0 0 .577.577.58.58 0 0 0 .577-.577.58.58 0 0 0-.385-.544zm-.192.736c-.106 0-.192-.086-.192-.192s.086-.192.192-.192.192.086.192.192-.086.192-.192.192z"
                     />
                     <path
                        id="D"
                        d="M44.665 75.025v-1.75c0-.53-.431-.962-.962-.962s-.962.431-.962.962v1.75a1.35 1.35 0 0 0 .962 2.288 1.35 1.35 0 0 0 .962-2.288zm-.962 1.904c-.53 0-.962-.431-.962-.962 0-.273.117-.534.321-.717l.064-.057v-1.918a.58.58 0 0 1 .577-.577.58.58 0 0 1 .577.577v1.918l.064.057c.204.182.321.444.321.717 0 .53-.431.962-.962.962z"
                     />
                     <path
                        id="E"
                        d="M43.703 71.312c-1.929 0-3.498 1.569-3.498 3.498 0 1.586 1.061 2.929 2.51 3.356v.912c0 .129.105.234.234.234h1.506c.129 0 .234-.105.234-.234v-.912c1.449-.427 2.51-1.77 2.51-3.356 0-1.929-1.569-3.498-3.498-3.498zm.519 7.531h-1.038v-.574c.343.051.695.051 1.038 0zm-.519-1.004c-1.67 0-3.029-1.359-3.029-3.029s1.359-3.029 3.029-3.029 3.029 1.359 3.029 3.029-1.359 3.029-3.029 3.029z"
                     />
                     <path
                        id="F"
                        d="M365.963 28.243c-1.329.001-2.406-1.093-2.407-2.443s1.076-2.444 2.405-2.445 2.406 1.093 2.407 2.443-1.076 2.444-2.405 2.445"
                     />
                     <path id="G" d="M364.674 24.578l.632 1.12.458-.456z" />
                     <path id="H" d="M470.657 28.267a2.41 2.41 0 0 1-.002-4.835 2.41 2.41 0 1 1 .002 4.835" />
                     <path id="I" d="M470.572 27.512c-.249 0-.451-.203-.451-.453s.201-.453.45-.454.451.203.451.453-.201.453-.45.454" />
                     <path
                        id="J"
                        d="M115.4 23.575a2.81 2.81 0 0 0-2.805 2.805 2.81 2.81 0 0 0 2.805 2.805 2.81 2.81 0 0 0 2.805-2.805 2.81 2.81 0 0 0-2.805-2.805zm1.786 4.218l-.101-.101c-.103-.103-.27-.103-.373 0s-.103.27 0 .373l.101.101c-.389.308-.88.493-1.413.493s-1.024-.184-1.413-.493l.101-.101c.103-.103.103-.27 0-.373s-.27-.103-.373 0l-.101.101c-.256-.324-.427-.718-.477-1.149h.145c.146 0 .264-.118.264-.264s-.118-.264-.264-.264h-.145c.05-.431.22-.825.477-1.149l.101.101c.103.103.27.103.373 0s.103-.27 0-.373l-.101-.101c.324-.257.718-.427 1.149-.477v.145c0 .146.118.264.264.264s.264-.118.264-.264v-.145c.431.05.826.22 1.149.477l-.101.101c-.103.103-.103.27 0 .373s.27.103.373 0l.101-.101c.256.324.427.718.477 1.149h-.145c-.146 0-.264.118-.264.264s.118.264.264.264h.145c-.05.431-.22.825-.477 1.149z"
                     />
                     <path id="K" d="M115.496 25.911l-.988.988c-.103.103-.103.27 0 .373s.27.103.373 0l.988-.988c.103-.103.103-.27 0-.373s-.27-.103-.373 0z" />
                     <path
                        id="L"
                        d="M115.4 22.445a3.94 3.94 0 0 0-3.935 3.935c0 1.784 1.194 3.295 2.824 3.775v1.026c0 .146.118.264.264.264h1.695c.146 0 .264-.118.264-.264v-1.026c1.631-.481 2.824-1.991 2.824-3.775a3.94 3.94 0 0 0-3.935-3.935zm.584 8.473h-1.167v-.646c.386.057.782.057 1.167 0zm-.584-1.13c-1.879 0-3.408-1.529-3.408-3.408s1.529-3.408 3.408-3.408 3.408 1.529 3.408 3.408-1.529 3.408-3.408 3.408z"
                     />
                     <path id="M" d="M19.504 30.045v3.522l8.197-3.522v3.522z" />
                  </defs>
                  <g transform="translate(-16.566 -4.246)">
                     <text xml:space="preserve" x="200.049" y="42.268" class="F H I">
                        <tspan x="200.049" y="42.268">{{ plc.ch1ValvePosition.toFixed(1) }} %</tspan>
                     </text>
                     <text xml:space="preserve" x="297.727" y="46.52" class="F H I">
                        <tspan x="297.727" y="46.52">{{ plc.ch1LowOutletPresure.toFixed(1) }} Bar</tspan>
                     </text>
                     <g transform="matrix(1.125 0 0 1.125 248.573086 -57.711434)">
                        <use xlink:href="#C" />
                        <use xlink:href="#D" />
                        <use xlink:href="#E" />
                     </g>
                     <text xml:space="preserve" x="297.595" y="19.889" class="F H I">
                        <tspan x="297.595" y="19.889">{{ plc.ch1LowInletTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <g transform="matrix(1.125 0 0 1.125 279.343168 -30.717456)">
                        <use xlink:href="#C" />
                        <use xlink:href="#D" />
                        <use xlink:href="#E" />
                     </g>
                     <text xml:space="preserve" x="328.365" y="46.883" class="F H I">
                        <tspan x="328.365" y="46.883">{{ plc.ch1LowOutletTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <text xml:space="preserve" x="297.595" y="11.716" fill="red" class="F H I">
                        <tspan x="297.595" y="11.716">{{ plc.ch1HeatCurveTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <g class="B D E">
                        <path d="M365.962 31.214v-3.057" />
                        <use xlink:href="#F" class="C G" />
                        <path d="M364.674 24.578l2.406 2.444" />
                     </g>
                     <use xlink:href="#G" class="B C D J" />
                     <g class="E B D">
                        <path d="M418.309 31.214v-3.057" />
                        <use xlink:href="#F" x="52.347" class="C G" />
                        <path d="M417.021 24.578l2.406 2.444" />
                     </g>
                     <use xlink:href="#G" x="52.347" class="B C D J" />
                     <g class="B D E">
                        <path d="M470.572 31.289v-3.022" />
                        <use xlink:href="#H" class="C G" />
                        <path d="M470.572 27.058v-3.022" />
                     </g>
                     <use xlink:href="#I" />
                     <path d="M270.285 30.877h236.039v2H270.285z" fill="#c80000" />
                     <g class="B D E">
                        <path d="M470.572 57.864v-3.022" />
                        <use xlink:href="#H" y="26.575" class="C G" />
                        <path d="M470.572 53.633v-3.022" />
                     </g>
                     <use xlink:href="#I" y="26.574" />
                     <g class="B D E">
                        <path d="M365.962 57.864v-3.057" />
                        <use xlink:href="#F" y="26.65" class="C G" />
                        <path d="M364.674 51.228l2.406 2.444" />
                     </g>
                     <use xlink:href="#G" y="26.65" class="B C D J" />
                     <g transform="matrix(1.504833 0 0 1.492279 310.31938 -66.935526)" class="B E">
                        <rect width="5.345" height="8.195" x="69.089" y="74.458" ry="1.563" stroke-width=".362" paint-order="markers stroke fill" class="C" />
                        <path d="M69.106 78.606l5.312-.1" stroke-width=".284" />
                        <path d="M71.177 82.758h1.169v.797h-1.169z" stroke-width=".206" paint-order="markers stroke fill" class="C" />
                     </g>
                     <path d="M269.831 57.775h235.874v2H269.831z" fill="#1300e3" />
                     <g class="B D E">
                        <path d="M51.034 30.984v-3.057" />
                        <use xlink:href="#F" x="-314.928" y="-0.229" class="C G" />
                        <path d="M49.747 24.348l2.406 2.444" />
                     </g>
                     <use xlink:href="#G" x="-314.927" y="-0.23" class="B C D J" />
                     <text xml:space="preserve" x="20.041" y="45.917" font-size="5.644" class="F">
                        <tspan x="20.041" y="45.917" font-weight="normal">
                           {{ t("components.climatix.network") }}
                        </tspan>
                     </text>
                     <g class="B D E">
                        <path d="M83.217 30.984v-3.057" />
                        <use xlink:href="#F" x="-282.745" y="-0.229" class="C G" />
                        <path d="M81.929 24.348l2.406 2.444" />
                     </g>
                     <use xlink:href="#G" x="-282.745" y="-0.23" class="B C D J" />
                     <use xlink:href="#J" />
                     <use xlink:href="#K" />
                     <use xlink:href="#L" />
                     <path d="M26.134 30.877h221.139v2H26.134z" fill="#e70000" />
                     <g class="B">
                        <use xlink:href="#M" class="K L" />
                        <g class="D E">
                           <path d="M50.702 58.208v-3.057" />
                           <use xlink:href="#F" x="-315.26" y="26.994" class="C G" />
                           <path d="M49.414 51.572l2.406 2.444" />
                        </g>
                        <use xlink:href="#G" x="-315.26" y="26.994" class="C D J" />
                     </g>
                     <use xlink:href="#J" y="26.914" />
                     <use xlink:href="#K" y="26.914" />
                     <use xlink:href="#L" y="26.914" />
                     <use xlink:href="#J" x="182.339" y="26.756" />
                     <use xlink:href="#K" x="182.339" y="26.757" />
                     <use xlink:href="#L" x="182.339" y="26.757" />
                     <path d="M26.335 57.775h221.092v2H26.335z" fill="#450097" />
                     <g class="B">
                        <use xlink:href="#M" x="0.047" y="26.999" class="K L" />
                        <g class="D E">
                           <path d="M83.051 58.208v-3.057" />
                           <use xlink:href="#F" x="-282.911" y="26.994" class="C G" />
                           <path d="M81.763 51.572l2.406 2.444" />
                        </g>
                        <use xlink:href="#G" x="-282.911" y="26.994" class="C D J" />
                        <g class="M">
                           <circle :fill="getPumpStatus(plc.ch1PumpAlarm, plc.ch1PumpStatus)" cx="390.448" cy="32.063" r="5.853" />
                           <path d="M388.185 37.514l7.917-4.086" class="E" />
                           <path d="M388.185 26.593l7.917 4.086" class="J" />
                        </g>
                        <g class="K L">
                           <use xlink:href="#M" x="485.969" y="0.046" />
                           <use xlink:href="#M" x="485.969" y="26.974" />
                        </g>
                     </g>
                     <text xml:space="preserve" x="513.125" y="47.579" font-size="5.644" class="F">
                        <tspan x="513.125" y="47.579" font-weight="normal" text-anchor="end">
                           {{ t("components.climatix.ch") }}
                        </tspan>
                     </text>
                     <g transform="matrix(1.325544 0 0 1.329832 104.49318 -80.327804)">
                        <path d="M66.585 101.915h11.159v5.646H66.585z" paint-order="markers stroke fill" class="K" />
                        <g class="B">
                           <g stroke-width=".199">
                              <path fill="#ffa400" d="M66.585 101.915v5.575l11.062-5.575v5.575z" />
                              <path d="M72.147 104.744l-.067-4.861" class="E" />
                           </g>
                           <circle cx="72.116" cy="97.182" r="2.873" fill="#a7a7a7" stroke-width=".35" paint-order="markers stroke fill" class="C" />
                        </g>
                     </g>
                     <g class="K">
                        <path d="M165.363 30.117h8.197v3.522h-8.197z" paint-order="markers stroke fill" />
                        <use xlink:href="#M" x="145.859" y="0.072" class="B M" />
                        <path d="M165.363 57.003h8.197v3.522h-8.197z" paint-order="markers stroke fill" />
                        <use xlink:href="#M" x="145.859" y="26.958" class="B M" />
                     </g>
                     <rect width="25.288" height="44.474" x="245.899" y="24.526" ry="4.31" fill="url(#A)" />
                     <text xml:space="preserve" x="258.543" y="48.733" font-size="7.056" class="F">
                        <tspan :visibility="getSectionStatus(plc.ch1Status)" x="258.543" y="48.733" font-weight="bold" class="I K">
                           {{ t("components.climatix.ch1Short") }}
                        </tspan>
                     </text>
                     <text xml:space="preserve" x="115.4" y="20.126" class="F H I">
                        <tspan x="115.4" y="20.126">{{ plc.chHighInletPresure.toFixed(1) }} Bar</tspan>
                     </text>
                     <text xml:space="preserve" x="115.119" y="47.034" class="F H I">
                        <tspan x="115.119" y="47.034">{{ plc.chHighOutletPresure.toFixed(1) }} Bar</tspan>
                     </text>
                     <text xml:space="preserve" style="white-space: pre" x="568.322" y="-47.114" text-anchor="end" class="F H">
                        <tspan x="493.777" y="17.813">{{ plc.outsideTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <path
                        d="M508.694 19.791c0 .355-.288.643-.643.643s-.643-.288-.643-.643.288-.643.643-.643.643.288.643.643zm2.379-3.601h1.576v-1.286h-1.576zm0-3.537v1.286h1.576v-1.286zm0 5.788h1.576v-1.286h-1.576zm-.965-.731c.548.559.868 1.317.868 2.082 0 1.631-1.327 2.958-2.958 2.958s-2.958-1.327-2.958-2.958c0-.764.319-1.521.866-2.079l.002-3.934c0-1.152.938-2.09 2.09-2.09s2.09.938 2.09 2.09zm-.418 2.082c0-.489-.237-.977-.635-1.305l-.234-.193v-4.515c0-.443-.361-.804-.804-.804s-.804.361-.804.804l-.002 4.517-.233.193c-.396.328-.633.815-.633 1.303 0 .922.75 1.672 1.672 1.672s1.672-.75 1.672-1.672zm-5.949 1.672h-4.019c-.355 0-.643-.289-.643-.643v-7.926l2.669-2.435 2.669-2.435 2.606 2.377h1.908l-4.514-4.118-8.24 7.517.867.95.749-.683v6.752a1.93 1.93 0 0 0 1.929 1.929h5.255a4.26 4.26 0 0 1-.86-1.286z"
                        fill="url(#B)"
                     />
                  </g>
               </svg>
               <!-- graphic double heating -->
               <svg
                  v-if="isDoubleHeatingPlcType(plc)"
                  class="d-none d-lg-block"
                  xmlns="http://www.w3.org/2000/svg"
                  xmlns:xlink="http://www.w3.org/1999/xlink"
                  viewBox="0 0 500.958 123"
                  xmlns:v="https://vecta.io/nano"
               >
                  <svg:style>
                     <![CDATA[.B{stroke:#000}.C{stroke-linejoin:round}.D{stroke-width:.282}.E{fill:none}.F{font-family:sans-serif}.G{text-anchor:middle}.H{stroke-linecap:round}.I{font-size:6.35px}.J{fill-rule:evenodd}.K{fill:#fff}.L{stroke-width:.3}.M{stroke-width:.298}.N{font-size:5.644px}.O{font-weight:400}.P{text-anchor:end}.Q{stroke-width:.362}.R{stroke-width:.284}.S{stroke-width:.206}.T{stroke-width:.199}]]>
                  </svg:style>
                  <defs>
                     <linearGradient id="A" gradientUnits="userSpaceOnUse">
                        <stop offset="0" stop-color="#00f" />
                        <stop offset=".584" stop-color="#a00" />
                        <stop offset="1" stop-color="red" />
                     </linearGradient>
                     <linearGradient
                        xlink:href="#A"
                        id="B"
                        gradientTransform="matrix(0.97966102,0,0,0.83492357,54.201374,-57.023478)"
                        x1="221.49"
                        y1="150.94"
                        x2="195.677"
                        y2="97.672"
                     />
                     <linearGradient id="C" x1="504.413" y1="6.284" x2="504.413" y2="22.749" gradientUnits="userSpaceOnUse">
                        <stop offset="0" stop-color="#2af598" />
                        <stop offset="1" stop-color="#009efd" />
                     </linearGradient>
                     <linearGradient
                        xlink:href="#A"
                        id="D"
                        gradientTransform="matrix(0.97966102,0,0,0.83492357,54.215938,-1.5105197)"
                        x1="221.49"
                        y1="150.94"
                        x2="195.677"
                        y2="97.672"
                     />
                     <path
                        id="E"
                        d="M43.896 75.423v-1.636h-.385v1.636a.58.58 0 0 0-.385.544.58.58 0 0 0 .577.577.58.58 0 0 0 .577-.577.58.58 0 0 0-.385-.544zm-.192.736c-.106 0-.192-.086-.192-.192s.086-.192.192-.192.192.086.192.192-.086.192-.192.192z"
                     />
                     <path
                        id="F"
                        d="M44.665 75.025v-1.75c0-.53-.431-.962-.962-.962s-.962.431-.962.962v1.75a1.35 1.35 0 0 0 .962 2.288 1.35 1.35 0 0 0 .962-2.288zm-.962 1.904c-.53 0-.962-.431-.962-.962 0-.273.117-.534.321-.717l.064-.057v-1.918a.58.58 0 0 1 .577-.577.58.58 0 0 1 .577.577v1.918l.064.057c.204.182.321.444.321.717 0 .53-.431.962-.962.962z"
                     />
                     <path
                        id="G"
                        d="M43.703 71.312c-1.929 0-3.498 1.569-3.498 3.498 0 1.586 1.061 2.929 2.51 3.356v.912c0 .129.105.234.234.234h1.506c.129 0 .234-.105.234-.234v-.912c1.449-.427 2.51-1.77 2.51-3.356 0-1.929-1.569-3.498-3.498-3.498zm.519 7.531h-1.038v-.574c.343.051.695.051 1.038 0zm-.519-1.004c-1.67 0-3.029-1.359-3.029-3.029s1.359-3.029 3.029-3.029 3.029 1.359 3.029 3.029-1.359 3.029-3.029 3.029z"
                     />
                     <path
                        id="H"
                        d="M365.963 28.243c-1.329.001-2.406-1.093-2.407-2.443s1.076-2.444 2.405-2.445 2.406 1.093 2.407 2.443-1.076 2.444-2.405 2.445"
                     />
                     <path id="I" d="M364.674 24.578l.632 1.12.458-.456z" />
                     <path id="J" d="M470.657 28.267a2.41 2.41 0 0 1-.002-4.835 2.41 2.41 0 1 1 .002 4.835" />
                     <path id="K" d="M470.572 27.512c-.249 0-.451-.203-.451-.453s.201-.453.45-.454.451.203.451.453-.201.453-.45.454" />
                     <path
                        id="L"
                        d="M115.4 23.575a2.81 2.81 0 0 0-2.805 2.805 2.81 2.81 0 0 0 2.805 2.805 2.81 2.81 0 0 0 2.805-2.805 2.81 2.81 0 0 0-2.805-2.805zm1.786 4.218l-.101-.101c-.103-.103-.27-.103-.373 0s-.103.27 0 .373l.101.101c-.389.308-.88.493-1.413.493s-1.024-.184-1.413-.493l.101-.101c.103-.103.103-.27 0-.373s-.27-.103-.373 0l-.101.101c-.256-.324-.427-.718-.477-1.149h.145c.146 0 .264-.118.264-.264s-.118-.264-.264-.264h-.145c.05-.431.22-.825.477-1.149l.101.101c.103.103.27.103.373 0s.103-.27 0-.373l-.101-.101c.324-.257.718-.427 1.149-.477v.145c0 .146.118.264.264.264s.264-.118.264-.264v-.145c.431.05.826.22 1.149.477l-.101.101c-.103.103-.103.27 0 .373s.27.103.373 0l.101-.101c.256.324.427.718.477 1.149h-.145c-.146 0-.264.118-.264.264s.118.264.264.264h.145c-.05.431-.22.825-.477 1.149z"
                     />
                     <path id="M" d="M115.496 25.911l-.988.988c-.103.103-.103.27 0 .373s.27.103.373 0l.988-.988c.103-.103.103-.27 0-.373s-.27-.103-.373 0z" />
                     <path
                        id="N"
                        d="M115.4 22.445a3.94 3.94 0 0 0-3.935 3.935c0 1.784 1.194 3.295 2.824 3.775v1.026c0 .146.118.264.264.264h1.695c.146 0 .264-.118.264-.264v-1.026c1.631-.481 2.824-1.991 2.824-3.775a3.94 3.94 0 0 0-3.935-3.935zm.584 8.473h-1.167v-.646c.386.057.782.057 1.167 0zm-.584-1.13c-1.879 0-3.408-1.529-3.408-3.408s1.529-3.408 3.408-3.408 3.408 1.529 3.408 3.408-1.529 3.408-3.408 3.408z"
                     />
                     <path id="O" d="M19.504 30.045v3.522l8.197-3.522v3.522z" />
                     <path id="P" d="M66.585 101.915v5.575l11.062-5.575v5.575z" />
                  </defs>
                  <g transform="translate(-16.566 -4.246)">
                     <text xml:space="preserve" x="200.049" y="42.268" class="F G I">
                        <tspan x="200.049" y="42.268">{{ plc.ch1ValvePosition.toFixed(1) }} %</tspan>
                     </text>
                     <text xml:space="preserve" x="297.727" y="46.52" class="F G I">
                        <tspan x="297.727" y="46.52">{{ plc.ch1LowOutletPresure.toFixed(1) }} Bar</tspan>
                     </text>
                     <g transform="matrix(1.125 0 0 1.125 248.573086 -57.711434)">
                        <use xlink:href="#E" />
                        <use xlink:href="#F" />
                        <use xlink:href="#G" />
                     </g>
                     <text xml:space="preserve" x="297.595" y="19.889" class="F G I">
                        <tspan x="297.595" y="19.889">{{ plc.ch1LowInletTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <g transform="matrix(1.125 0 0 1.125 279.343168 -30.717456)">
                        <use xlink:href="#E" />
                        <use xlink:href="#F" />
                        <use xlink:href="#G" />
                     </g>
                     <text xml:space="preserve" x="328.365" y="46.883" class="F G I">
                        <tspan x="328.365" y="46.883">{{ plc.ch1LowOutletTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <text xml:space="preserve" x="297.595" y="11.716" fill="red" class="F G I">
                        <tspan x="297.595" y="11.716">{{ plc.ch1HeatCurveTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <g class="B D E">
                        <path d="M365.962 31.214v-3.057" />
                        <use xlink:href="#H" class="C H" />
                        <path d="M364.674 24.578l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" class="B C D J" />
                     <g class="E B D">
                        <path d="M418.309 31.214v-3.057" />
                        <use xlink:href="#H" x="52.347" class="C H" />
                        <path d="M417.021 24.578l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" x="52.347" class="B C D J" />
                     <g class="B D E">
                        <path d="M470.572 31.289v-3.022" />
                        <use xlink:href="#J" class="C H" />
                        <path d="M470.572 27.058v-3.022" />
                     </g>
                     <use xlink:href="#K" />
                     <path d="M270.285 30.877h236.039v2H270.285z" fill="#c80000" />
                     <g class="B D E">
                        <path d="M470.572 57.864v-3.022" />
                        <use xlink:href="#J" y="26.575" class="C H" />
                        <path d="M470.572 53.633v-3.022" />
                     </g>
                     <use xlink:href="#K" y="26.574" />
                     <g class="B D E">
                        <path d="M365.962 57.864v-3.057" />
                        <use xlink:href="#H" y="26.65" class="C H" />
                        <path d="M364.674 51.228l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" y="26.65" class="B C D J" />
                     <g transform="matrix(1.504833 0 0 1.492279 310.31938 -66.935526)" class="B E">
                        <rect width="5.345" height="8.195" x="69.089" y="74.458" ry="1.563" paint-order="markers stroke fill" class="C Q" />
                        <path d="M69.106 78.606l5.312-.1" class="R" />
                        <path d="M71.177 82.758h1.169v.797h-1.169z" paint-order="markers stroke fill" class="C S" />
                     </g>
                     <path d="M269.831 57.775h235.874v2H269.831z" fill="#1300e3" />
                     <g class="B D E">
                        <path d="M51.034 30.984v-3.057" />
                        <use xlink:href="#H" x="-314.928" y="-0.229" class="C H" />
                        <path d="M49.747 24.348l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" x="-314.927" y="-0.23" class="B C D J" />
                     <text xml:space="preserve" x="20.041" y="45.917" class="F N">
                        <tspan x="20.041" y="45.917" font-weight="normal">
                           {{ t("components.climatix.network") }}
                        </tspan>
                     </text>
                     <g class="B D E">
                        <path d="M83.217 30.984v-3.057" />
                        <use xlink:href="#H" x="-282.745" y="-0.229" class="C H" />
                        <path d="M81.929 24.348l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" x="-282.745" y="-0.23" class="B C D J" />
                     <use xlink:href="#L" />
                     <use xlink:href="#M" />
                     <use xlink:href="#N" />
                     <path d="M26.134 30.877h221.139v2H26.134zm120.482 55.62H258.13v2H146.616z" fill="#e70000" />
                     <g class="B">
                        <use xlink:href="#O" class="K M" />
                        <g class="D E">
                           <path d="M50.702 58.208v-3.057" />
                           <use xlink:href="#H" x="-315.26" y="26.994" class="C H" />
                           <path d="M49.414 51.572l2.406 2.444" />
                        </g>
                        <use xlink:href="#I" x="-315.26" y="26.994" class="C D J" />
                     </g>
                     <use xlink:href="#L" y="26.914" />
                     <use xlink:href="#M" y="26.914" />
                     <use xlink:href="#N" y="26.914" />
                     <use xlink:href="#L" x="182.339" y="26.756" />
                     <use xlink:href="#M" x="182.339" y="26.757" />
                     <use xlink:href="#N" x="182.339" y="26.757" />
                     <path d="M26.335 57.775h221.092v2H26.335zm105.843 55.63h119.161v2H132.178z" fill="#450097" />
                     <g class="B">
                        <use xlink:href="#O" x="0.047" y="26.999" class="K M" />
                        <g class="D E">
                           <path d="M83.051 58.208v-3.057" />
                           <use xlink:href="#H" x="-282.911" y="26.994" class="C H" />
                           <path d="M81.763 51.572l2.406 2.444" />
                        </g>
                        <use xlink:href="#I" x="-282.911" y="26.994" class="C D J" />
                        <g class="L">
                           <circle :fill="getPumpStatus(plc.ch1PumpAlarm, plc.ch1PumpStatus)" cx="390.448" cy="32.063" r="5.853" />
                           <path d="M388.185 37.514l7.917-4.086" class="E" />
                           <path d="M388.185 26.593l7.917 4.086" class="J" />
                        </g>
                        <g class="K M">
                           <use xlink:href="#O" x="485.969" y="0.046" />
                           <use xlink:href="#O" x="485.969" y="26.974" />
                        </g>
                     </g>
                     <text xml:space="preserve" x="513.125" y="47.579" class="F N">
                        <tspan x="513.125" y="47.579" font-weight="normal" class="P">
                           {{ t("components.climatix.ch") }}
                        </tspan>
                     </text>
                     <g transform="matrix(1.325544 0 0 1.329832 104.49318 -80.327804)">
                        <path d="M66.585 101.915h11.159v5.646H66.585z" paint-order="markers stroke fill" class="K" />
                        <g class="B">
                           <g class="T">
                              <use xlink:href="#P" fill="#ffa400" />
                              <path d="M72.147 104.744l-.067-4.861" class="E" />
                           </g>
                           <circle cx="72.116" cy="97.182" r="2.873" fill="#a7a7a7" stroke-width=".35" paint-order="markers stroke fill" class="C" />
                        </g>
                     </g>
                     <path d="M148.598 31.454v56.364h-2V31.454z" fill="#e70000" />
                     <path d="M134.154 59.164v55.122h-2V59.164z" fill="#450097" />
                     <g class="K">
                        <path d="M165.363 30.117h8.197v3.522h-8.197z" paint-order="markers stroke fill" />
                        <use xlink:href="#O" x="145.859" y="0.072" class="B L" />
                        <path d="M165.363 57.003h8.197v3.522h-8.197z" paint-order="markers stroke fill" />
                        <use xlink:href="#O" x="145.859" y="26.958" class="B L" />
                     </g>
                     <rect width="25.288" height="44.474" x="245.899" y="24.526" ry="4.31" fill="url(#B)" />
                     <text xml:space="preserve" x="258.543" y="48.733" font-size="7.056" class="F">
                        <tspan x="258.543" y="48.733" font-weight="bold" class="G K">
                           {{ t("components.climatix.ch1Short") }}
                        </tspan>
                     </text>
                     <text xml:space="preserve" x="115.4" y="20.126" class="F G I">
                        <tspan x="115.4" y="20.126">{{ plc.chHighInletPresure.toFixed(1) }} Bar</tspan>
                     </text>
                     <text xml:space="preserve" x="115.119" y="47.034" class="F G I">
                        <tspan x="115.119" y="47.034">{{ plc.chHighOutletPresure.toFixed(1) }} Bar</tspan>
                     </text>
                     <text xml:space="preserve" style="white-space: pre" x="568.322" y="-47.114" class="F I P">
                        <tspan x="493.777" y="17.813">{{ plc.outsideTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <path
                        d="M508.694 19.791c0 .355-.288.643-.643.643s-.643-.288-.643-.643.288-.643.643-.643.643.288.643.643zm2.379-3.601h1.576v-1.286h-1.576zm0-3.537v1.286h1.576v-1.286zm0 5.788h1.576v-1.286h-1.576zm-.965-.731c.548.559.868 1.317.868 2.082 0 1.631-1.327 2.958-2.958 2.958s-2.958-1.327-2.958-2.958c0-.764.319-1.521.866-2.079l.002-3.934c0-1.152.938-2.09 2.09-2.09s2.09.938 2.09 2.09zm-.418 2.082c0-.489-.237-.977-.635-1.305l-.234-.193v-4.515c0-.443-.361-.804-.804-.804s-.804.361-.804.804l-.002 4.517-.233.193c-.396.328-.633.815-.633 1.303 0 .922.75 1.672 1.672 1.672s1.672-.75 1.672-1.672zm-5.949 1.672h-4.019c-.355 0-.643-.289-.643-.643v-7.926l2.669-2.435 2.669-2.435 2.606 2.377h1.908l-4.514-4.118-8.24 7.517.867.95.749-.683v6.752a1.93 1.93 0 0 0 1.929 1.929h5.255a4.26 4.26 0 0 1-.86-1.286z"
                        fill="url(#C)"
                     />
                     <text xml:space="preserve" x="200.064" y="97.78" class="F G I">
                        <tspan x="200.064" y="97.78">{{ plc.ch2ValvePosition.toFixed(1) }} %</tspan>
                     </text>
                     <text xml:space="preserve" x="297.742" y="102.032" class="F G I">
                        <tspan x="297.742" y="102.032">{{ plc.ch2LowOutletPresure.toFixed(1) }} Bar</tspan>
                     </text>
                     <g transform="matrix(1.125 0 0 1.125 248.587647 -2.198461)">
                        <use xlink:href="#E" />
                        <use xlink:href="#F" />
                        <use xlink:href="#G" />
                     </g>
                     <text xml:space="preserve" x="297.61" y="75.402" class="F G I">
                        <tspan x="297.61" y="75.402">{{ plc.ch1LowInletTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <g transform="matrix(1.125 0 0 1.125 279.357733 24.795514)">
                        <use xlink:href="#E" />
                        <use xlink:href="#F" />
                        <use xlink:href="#G" />
                     </g>
                     <text xml:space="preserve" x="328.38" y="102.396" class="F G I">
                        <tspan x="328.38" y="102.396">{{ plc.ch2LowOutletTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <text xml:space="preserve" x="297.61" y="67.229" fill="red" class="F G I">
                        <tspan x="297.61" y="67.229">{{ plc.ch1HeatCurveTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <g class="B D E">
                        <path d="M365.976 86.727V83.67" />
                        <use xlink:href="#H" x="0.014" y="55.513" class="C H" />
                        <path d="M364.689 80.091l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" x="0.015" y="55.513" class="B C D J" />
                     <g class="E B D">
                        <path d="M418.324 86.727V83.67" />
                        <use xlink:href="#H" x="52.362" y="55.513" class="C H" />
                        <path d="M417.036 80.091l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" x="52.362" y="55.513" class="B C D J" />
                     <g class="B D E">
                        <path d="M470.586 86.802V83.78" />
                        <use xlink:href="#J" x="0.015" y="55.513" class="C H" />
                        <path d="M470.586 82.571v-3.022" />
                     </g>
                     <use xlink:href="#K" x="0.014" y="55.513" />
                     <path d="M270.3 86.39h236.039v2H270.3z" fill="#c80000" />
                     <g class="B D E">
                        <path d="M470.586 113.377v-3.022" />
                        <use xlink:href="#J" x="0.015" y="82.088" class="C H" />
                        <path d="M470.586 109.146v-3.022" />
                     </g>
                     <use xlink:href="#K" x="0.014" y="82.087" />
                     <g class="B D E">
                        <path d="M365.976 113.377v-3.057" />
                        <use xlink:href="#H" x="0.014" y="82.164" class="C H" />
                        <path d="M364.689 106.741l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" x="0.015" y="82.163" class="B C D J" />
                     <g transform="matrix(1.504833 0 0 1.492279 310.33396 -11.422565)" class="B E">
                        <rect width="5.345" height="8.195" x="69.089" y="74.458" ry="1.563" paint-order="markers stroke fill" class="C Q" />
                        <path d="M69.106 78.606l5.312-.1" class="R" />
                        <path d="M71.177 82.758h1.169v.797h-1.169z" paint-order="markers stroke fill" class="C S" />
                     </g>
                     <path d="M269.846 113.288H505.72v2H269.846z" fill="#1300e3" />
                     <use xlink:href="#L" x="182.354" y="82.269" />
                     <use xlink:href="#M" x="182.354" y="82.27" />
                     <use xlink:href="#N" x="182.354" y="82.27" />
                     <g class="B">
                        <g class="L">
                           <circle :fill="getPumpStatus(plc.ch2PumpAlarm, plc.ch2PumpStatus)" cx="390.463" cy="87.576" r="5.853" />
                           <path d="M388.2 93.027l7.917-4.086" class="E" />
                           <path d="M388.2 82.106l7.917 4.086" class="J" />
                        </g>
                        <g class="K M">
                           <use xlink:href="#O" x="485.984" y="55.559" />
                           <use xlink:href="#O" x="485.984" y="82.487" />
                        </g>
                     </g>
                     <text xml:space="preserve" x="513.14" y="103.092" class="F N">
                        <tspan x="513.14" y="103.092" font-weight="normal" class="P">
                           {{ t("components.climatix.ch") }}
                        </tspan>
                     </text>
                     <g transform="matrix(1.325544 0 0 1.329832 104.50775 -24.814831)">
                        <path d="M66.585 101.915h11.159v5.646H66.585z" paint-order="markers stroke fill" class="K" />
                        <g class="B">
                           <g class="T">
                              <use xlink:href="#P" fill="#ffa400" />
                              <path d="M72.147 104.744l-.067-4.861" class="E" />
                           </g>
                           <circle cx="72.116" cy="97.182" r="2.873" fill="#a7a7a7" stroke-width=".35" paint-order="markers stroke fill" class="C" />
                        </g>
                     </g>
                     <g class="K">
                        <path d="M165.377 85.63h8.197v3.522h-8.197z" paint-order="markers stroke fill" />
                        <use xlink:href="#O" x="145.873" y="55.585" class="B L" />
                        <path d="M165.377 112.516h8.197v3.522h-8.197z" paint-order="markers stroke fill" />
                        <use xlink:href="#O" x="145.873" y="82.471" class="B L" />
                     </g>
                     <rect width="25.288" height="44.474" x="245.913" y="80.039" ry="4.31" fill="url(#D)" />
                     <text xml:space="preserve" x="258.557" y="104.246" font-size="7.056" class="F">
                        <tspan :visibility="getSectionStatus(plc.ch2Status)" x="258.557" y="104.246" font-weight="bold" class="G K">
                           {{ t("components.climatix.ch2Short") }}
                        </tspan>
                     </text>
                  </g>
               </svg>
               <!-- graphic heating domestic -->
               <svg
                  v-if="isDomesticPlcType(plc)"
                  class="d-none d-lg-block"
                  xmlns="http://www.w3.org/2000/svg"
                  xmlns:xlink="http://www.w3.org/1999/xlink"
                  viewBox="0 0 500.958 138"
                  xmlns:v="https://vecta.io/nano"
               >
                  <svg:style>
                     <![CDATA[.B{stroke:#000}.C{stroke-linejoin:round}.D{stroke-width:.282}.E{fill:none}.F{font-family:sans-serif}.G{stroke-linecap:round}.H{fill-rule:evenodd}.I{text-anchor:middle}.J{fill:#fff}.K{font-size:6.35px}.L{stroke-width:.3}.M{font-size:5.644px}.N{font-weight:400}.O{stroke-width:.298}.P{text-anchor:end}.Q{fill:#e70000}.R{fill:#450097}.S{fill:#f1b345}.T{stroke-width:.362}.U{stroke-width:.284}.V{stroke-width:.206}.W{stroke-width:.199}]]>
                  </svg:style>
                  <defs>
                     <linearGradient id="A" gradientUnits="userSpaceOnUse">
                        <stop offset="0" stop-color="#00f" />
                        <stop offset=".584" stop-color="#a00" />
                        <stop offset="1" stop-color="red" />
                     </linearGradient>
                     <linearGradient
                        xlink:href="#A"
                        id="B"
                        x1="221.49"
                        y1="150.94"
                        x2="195.677"
                        y2="97.672"
                        gradientTransform="matrix(0.97966102,0,0,0.83492359,54.201373,-2.4952345)"
                     />
                     <linearGradient
                        xlink:href="#A"
                        id="C"
                        gradientTransform="matrix(0.97966102,0,0,0.83492357,54.201374,-57.023478)"
                        x1="221.49"
                        y1="150.94"
                        x2="195.677"
                        y2="97.672"
                     />
                     <linearGradient id="D" x1="504.413" y1="6.284" x2="504.413" y2="22.749" gradientUnits="userSpaceOnUse">
                        <stop offset="0" stop-color="#2af598" />
                        <stop offset="1" stop-color="#009efd" />
                     </linearGradient>
                     <path
                        id="E"
                        d="M43.896 75.423v-1.636h-.385v1.636a.58.58 0 0 0-.385.544.58.58 0 0 0 .577.577.58.58 0 0 0 .577-.577.58.58 0 0 0-.385-.544zm-.192.736c-.106 0-.192-.086-.192-.192s.086-.192.192-.192.192.086.192.192-.086.192-.192.192z"
                     />
                     <path
                        id="F"
                        d="M44.665 75.025v-1.75c0-.53-.431-.962-.962-.962s-.962.431-.962.962v1.75a1.35 1.35 0 0 0 .962 2.288 1.35 1.35 0 0 0 .962-2.288zm-.962 1.904c-.53 0-.962-.431-.962-.962 0-.273.117-.534.321-.717l.064-.057v-1.918a.58.58 0 0 1 .577-.577.58.58 0 0 1 .577.577v1.918l.064.057c.204.182.321.444.321.717 0 .53-.431.962-.962.962z"
                     />
                     <path
                        id="G"
                        d="M43.703 71.312c-1.929 0-3.498 1.569-3.498 3.498 0 1.586 1.061 2.929 2.51 3.356v.912c0 .129.105.234.234.234h1.506c.129 0 .234-.105.234-.234v-.912c1.449-.427 2.51-1.77 2.51-3.356 0-1.929-1.569-3.498-3.498-3.498zm.519 7.531h-1.038v-.574c.343.051.695.051 1.038 0zm-.519-1.004c-1.67 0-3.029-1.359-3.029-3.029s1.359-3.029 3.029-3.029 3.029 1.359 3.029 3.029-1.359 3.029-3.029 3.029z"
                     />
                     <path
                        id="H"
                        d="M365.963 28.243c-1.329.001-2.406-1.093-2.407-2.443s1.076-2.444 2.405-2.445 2.406 1.093 2.407 2.443-1.076 2.444-2.405 2.445"
                     />
                     <path id="I" d="M364.674 24.578l.632 1.12.458-.456z" />
                     <path id="J" d="M470.657 28.267a2.41 2.41 0 0 1-.002-4.835 2.41 2.41 0 1 1 .002 4.835" />
                     <path id="K" d="M470.572 27.512c-.249 0-.451-.203-.451-.453s.201-.453.45-.454.451.203.451.453-.201.453-.45.454" />
                     <path
                        id="L"
                        d="M115.4 23.575a2.81 2.81 0 0 0-2.805 2.805 2.81 2.81 0 0 0 2.805 2.805 2.81 2.81 0 0 0 2.805-2.805 2.81 2.81 0 0 0-2.805-2.805zm1.786 4.218l-.101-.101c-.103-.103-.27-.103-.373 0s-.103.27 0 .373l.101.101c-.389.308-.88.493-1.413.493s-1.024-.184-1.413-.493l.101-.101c.103-.103.103-.27 0-.373s-.27-.103-.373 0l-.101.101c-.256-.324-.427-.718-.477-1.149h.145c.146 0 .264-.118.264-.264s-.118-.264-.264-.264h-.145c.05-.431.22-.825.477-1.149l.101.101c.103.103.27.103.373 0s.103-.27 0-.373l-.101-.101c.324-.257.718-.427 1.149-.477v.145c0 .146.118.264.264.264s.264-.118.264-.264v-.145c.431.05.826.22 1.149.477l-.101.101c-.103.103-.103.27 0 .373s.27.103.373 0l.101-.101c.256.324.427.718.477 1.149h-.145c-.146 0-.264.118-.264.264s.118.264.264.264h.145c-.05.431-.22.825-.477 1.149z"
                     />
                     <path id="M" d="M115.496 25.911l-.988.988c-.103.103-.103.27 0 .373s.27.103.373 0l.988-.988c.103-.103.103-.27 0-.373s-.27-.103-.373 0z" />
                     <path
                        id="N"
                        d="M115.4 22.445a3.94 3.94 0 0 0-3.935 3.935c0 1.784 1.194 3.295 2.824 3.775v1.026c0 .146.118.264.264.264h1.695c.146 0 .264-.118.264-.264v-1.026c1.631-.481 2.824-1.991 2.824-3.775a3.94 3.94 0 0 0-3.935-3.935zm.584 8.473h-1.167v-.646c.386.057.782.057 1.167 0zm-.584-1.13c-1.879 0-3.408-1.529-3.408-3.408s1.529-3.408 3.408-3.408 3.408 1.529 3.408 3.408-1.529 3.408-3.408 3.408z"
                     />
                     <path id="O" d="M19.504 30.045v3.522l8.197-3.522v3.522z" />
                     <path id="P" d="M66.585 101.915v5.575l11.062-5.575v5.575z" />
                     <path id="Q" d="M165.363 30.117h8.197v3.522h-8.197z" />
                  </defs>
                  <g transform="translate(-16.566 -4.246)">
                     <text xml:space="preserve" x="199.942" y="94.782" class="F I K">
                        <tspan>{{ plc.dhwValvePosition.toFixed(1) }} %</tspan>
                     </text>
                     <text xml:space="preserve" x="200.049" y="42.268" class="F I K">
                        <tspan x="200.049" y="42.268">{{ plc.ch1ValvePosition.toFixed(1) }} %</tspan>
                     </text>
                     <g transform="matrix(1.125 0 0 1.125 248.573086 -2.729937)">
                        <use xlink:href="#E" />
                        <use xlink:href="#F" />
                        <use xlink:href="#G" />
                     </g>
                     <text xml:space="preserve" x="297.739" y="74.871" class="F I K">
                        <tspan x="297.739" y="74.871">{{ plc.dhwTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <text xml:space="preserve" x="297.739" y="67.756" fill="red" class="F I K">
                        <tspan x="297.739" y="67.756">{{ plc.dhwTempSet.toFixed(1) }} °C</tspan>
                     </text>
                     <text xml:space="preserve" x="297.727" y="46.52" class="F I K">
                        <tspan x="297.727" y="46.52">{{ plc.ch1LowOutletPresure.toFixed(1) }} Bar</tspan>
                     </text>
                     <g transform="matrix(1.125 0 0 1.125 248.573086 -57.711434)">
                        <use xlink:href="#E" />
                        <use xlink:href="#F" />
                        <use xlink:href="#G" />
                     </g>
                     <text xml:space="preserve" x="297.595" y="19.889" class="F I K">
                        <tspan x="297.595" y="19.889">{{ plc.ch1LowInletTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <g transform="matrix(1.125 0 0 1.125 279.343168 -30.717456)">
                        <use xlink:href="#E" />
                        <use xlink:href="#F" />
                        <use xlink:href="#G" />
                     </g>
                     <text xml:space="preserve" x="328.365" y="46.883" class="F I K">
                        <tspan x="328.365" y="46.883">{{ plc.ch1LowOutletTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <text xml:space="preserve" x="297.595" y="11.716" fill="red" class="F I K">
                        <tspan x="297.595" y="11.716">{{ plc.ch1HeatCurveTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <g class="B D E">
                        <path d="M365.962 31.214v-3.057" />
                        <use xlink:href="#H" class="C G" />
                        <path d="M364.674 24.578l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" class="B C D H" />
                     <g class="E B D">
                        <path d="M418.309 31.214v-3.057" />
                        <use xlink:href="#H" x="52.347" class="C G" />
                        <path d="M417.021 24.578l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" x="52.347" class="B C D H" />
                     <g class="B D E">
                        <path d="M470.572 31.289v-3.022" />
                        <use xlink:href="#J" class="C G" />
                        <path d="M470.572 27.058v-3.022" />
                     </g>
                     <use xlink:href="#K" />
                     <path d="M270.285 30.877h236.039v2H270.285z" fill="#c80000" />
                     <g class="B D E">
                        <path d="M470.572 57.864v-3.022" />
                        <use xlink:href="#J" y="26.575" class="C G" />
                        <path d="M470.572 53.633v-3.022" />
                     </g>
                     <use xlink:href="#K" y="26.574" />
                     <g class="B D E">
                        <path d="M365.962 57.864v-3.057" />
                        <use xlink:href="#H" y="26.65" class="C G" />
                        <path d="M364.674 51.228l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" y="26.65" class="B C D H" />
                     <g transform="matrix(1.504833 0 0 1.492279 310.31938 -66.935526)" class="B E">
                        <rect width="5.345" height="8.195" x="69.089" y="74.458" ry="1.563" paint-order="markers stroke fill" class="C T" />
                        <path d="M69.106 78.606l5.312-.1" class="U" />
                        <path d="M71.177 82.758h1.169v.797h-1.169z" paint-order="markers stroke fill" class="C V" />
                     </g>
                     <path d="M269.831 57.775h235.874v2H269.831z" fill="#1300e3" />
                     <g class="B D E">
                        <path d="M51.034 30.984v-3.057" />
                        <use xlink:href="#H" x="-314.928" y="-0.229" class="C G" />
                        <path d="M49.747 24.348l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" x="-314.927" y="-0.23" class="B C D H" />
                     <text xml:space="preserve" x="20.041" y="45.917" class="F M">
                        <tspan x="20.041" y="45.917" font-weight="normal">
                           {{ t("components.climatix.network") }}
                        </tspan>
                     </text>
                     <g class="B D E">
                        <path d="M83.217 30.984v-3.057" />
                        <use xlink:href="#H" x="-282.745" y="-0.229" class="C G" />
                        <path d="M81.929 24.348l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" x="-282.745" y="-0.23" class="B C D H" />
                     <use xlink:href="#L" />
                     <use xlink:href="#M" />
                     <use xlink:href="#N" />
                     <path d="M26.134 30.877h221.139v2H26.134z" class="Q" />
                     <g class="B">
                        <use xlink:href="#O" class="J O" />
                        <g class="D E">
                           <path d="M50.702 58.208v-3.057" />
                           <use xlink:href="#H" x="-315.26" y="26.994" class="C G" />
                           <path d="M49.414 51.572l2.406 2.444" />
                        </g>
                        <use xlink:href="#I" x="-315.26" y="26.994" class="C D H" />
                     </g>
                     <use xlink:href="#L" y="26.914" />
                     <use xlink:href="#M" y="26.914" />
                     <use xlink:href="#N" y="26.914" />
                     <use xlink:href="#L" x="182.339" y="26.756" />
                     <use xlink:href="#M" x="182.339" y="26.757" />
                     <use xlink:href="#N" x="182.339" y="26.757" />
                     <path d="M26.335 57.775h221.092v2H26.335z" class="R" />
                     <g class="B">
                        <use xlink:href="#O" x="0.047" y="26.999" class="J O" />
                        <g class="D E">
                           <path d="M83.051 58.208v-3.057" />
                           <use xlink:href="#H" x="-282.911" y="26.994" class="C G" />
                           <path d="M81.763 51.572l2.406 2.444" />
                        </g>
                        <use xlink:href="#I" x="-282.911" y="26.994" class="C D H" />
                        <g class="L">
                           <circle :fill="getPumpStatus(plc.ch1PumpAlarm, plc.ch1PumpStatus)" cx="390.448" cy="32.063" r="5.853" />
                           <path d="M388.185 37.514l7.917-4.086" class="E" />
                           <path d="M388.185 26.593l7.917 4.086" class="H" />
                        </g>
                        <g class="J O">
                           <use xlink:href="#O" x="485.969" y="0.046" />
                           <use xlink:href="#O" x="485.969" y="26.974" />
                        </g>
                     </g>
                     <text xml:space="preserve" x="513.125" y="47.579" class="F M">
                        <tspan x="513.125" y="47.579" font-weight="normal" class="P">
                           {{ t("components.climatix.ch") }}
                        </tspan>
                     </text>
                     <g transform="matrix(1.325544 0 0 1.329832 104.49318 -80.327804)">
                        <path d="M66.585 101.915h11.159v5.646H66.585z" paint-order="markers stroke fill" class="J" />
                        <g class="B">
                           <g class="W">
                              <use xlink:href="#P" fill="#ffa400" />
                              <path d="M72.147 104.744l-.067-4.861" class="E" />
                           </g>
                           <circle cx="72.116" cy="97.182" r="2.873" fill="#a7a7a7" stroke-width=".35" paint-order="markers stroke fill" class="C" />
                        </g>
                     </g>
                     <path d="M148.598 31.454v56.364h-2V31.454z" class="Q" />
                     <path d="M134.154 59.164v52.807h-2V59.164z" class="R" />
                     <g class="J">
                        <use xlink:href="#Q" paint-order="markers stroke fill" />
                        <use xlink:href="#O" x="145.859" y="0.072" class="B L" />
                        <use xlink:href="#Q" y="26.886" paint-order="markers stroke fill" />
                        <use xlink:href="#O" x="145.859" y="26.958" class="B L" />
                     </g>
                     <path d="M147.657 85.859h99.779v2h-99.779z" class="Q" />
                     <path d="M133.477 109.984h113.944v2H133.477z" class="R" />
                     <g transform="matrix(1.325544 0 0 1.329832 104.49318 -28.280521)">
                        <path d="M66.585 101.915h11.159v5.646H66.585z" paint-order="markers stroke fill" class="J" />
                        <g class="B">
                           <g class="W">
                              <use xlink:href="#P" fill="#ffa400" />
                              <path d="M72.147 104.744l-.067-4.861" class="E" />
                           </g>
                           <circle cx="72.116" cy="97.182" r="2.873" fill="#a7a7a7" stroke-width=".35" paint-order="markers stroke fill" class="C" />
                        </g>
                     </g>
                     <g class="J">
                        <use xlink:href="#Q" y="55.002" paint-order="markers stroke fill" />
                        <use xlink:href="#O" x="145.859" y="55.074" class="B L" />
                        <use xlink:href="#Q" y="79.07" paint-order="markers stroke fill" />
                        <use xlink:href="#O" x="145.859" y="79.142" class="B L" />
                     </g>
                     <g class="B D E">
                        <path d="M470.352 86.271v-3.022" />
                        <use xlink:href="#J" x="-0.219" y="54.982" class="C G" />
                        <path d="M470.352 82.04v-3.022" />
                     </g>
                     <use xlink:href="#K" x="-0.219" y="54.981" />
                     <path d="M270.055 85.859h236.65v2h-236.65z" class="S" />
                     <g class="B D E">
                        <path d="M470.352 110.199v-3.022" />
                        <use xlink:href="#J" x="-0.219" y="78.91" class="C G" />
                        <path d="M470.352 105.968v-3.022" />
                     </g>
                     <use xlink:href="#K" x="-0.219" y="78.91" />
                     <g class="B D E">
                        <path d="M365.889 110.199v-3.057" />
                        <use xlink:href="#H" x="-0.073" y="78.986" class="C G" />
                        <path d="M364.601 103.563l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" x="-0.073" y="78.985" class="B C D H" />
                     <g transform="matrix(1.504833 0 0 1.492279 310.17328 -14.599924)" class="B E">
                        <rect width="5.345" height="8.195" x="69.089" y="74.458" ry="1.563" paint-order="markers stroke fill" class="C T" />
                        <path d="M69.106 78.606l5.312-.1" class="U" />
                        <path d="M71.177 82.758h1.169v.797h-1.169z" paint-order="markers stroke fill" class="C V" />
                     </g>
                     <path d="M270.171 110.111h236.366v2H270.171z" fill="#00da31" />
                     <g class="B">
                        <g class="J O">
                           <use xlink:href="#O" x="485.75" y="55.027" />
                           <use xlink:href="#O" x="485.75" y="79.309" />
                        </g>
                        <g class="D E">
                           <path d="M297.739 110.199v-3.057" />
                           <use xlink:href="#H" x="-68.222" y="78.986" class="C G" />
                           <path d="M296.452 103.563l2.406 2.444" />
                        </g>
                        <use xlink:href="#I" x="-68.222" y="78.985" class="C D H" />
                     </g>
                     <text xml:space="preserve" x="513.338" y="75.583" class="F M">
                        <tspan x="513.338" y="75.583" font-weight="normal" class="P">
                           {{ t("components.climatix.waterWarm") }}
                        </tspan>
                     </text>
                     <text xml:space="preserve" x="513.338" y="99.831" class="F M">
                        <tspan x="513.338" y="99.831" font-weight="normal" class="P">
                           {{ t("components.climatix.waterCold") }}
                        </tspan>
                     </text>
                     <g class="B D E">
                        <path d="M365.889 133.239v-3.057" />
                        <use xlink:href="#H" x="-0.073" y="102.026" class="C G" />
                        <path d="M364.601 126.603l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" x="-0.073" y="102.025" class="B C D H" />
                     <g class="E B D">
                        <path d="M418.163 133.239v-3.057" />
                        <use xlink:href="#H" x="52.201" y="102.026" class="C G" />
                        <path d="M416.875 126.603l2.406 2.444" />
                     </g>
                     <use xlink:href="#I" x="52.201" y="102.025" class="B C D H" />
                     <g class="B D E">
                        <path d="M470.352 133.173v-3.022" />
                        <path d="M470.438 130.15a2.41 2.41 0 0 1-.002-4.835 2.41 2.41 0 0 1 .002 4.835" class="C G" />
                        <path d="M470.352 128.942v-3.022" />
                     </g>
                     <use xlink:href="#K" x="-0.219" y="101.883" />
                     <path d="M279.125 132.997h228.102v2H279.125z" class="S" />
                     <use xlink:href="#O" x="485.75" y="102.152" class="B J O" />
                     <text xml:space="preserve" x="513.338" y="122.995" class="F M">
                        <tspan x="513.338" y="122.995" font-weight="normal" class="P">
                           {{ t("components.climatix.circulation") }}
                        </tspan>
                     </text>
                     <g class="J">
                        <use xlink:href="#Q" x="156.084" y="102.139" paint-order="markers stroke fill" />
                        <use xlink:href="#O" x="301.943" y="102.211" class="B L" />
                     </g>
                     <g transform="matrix(-1 0 0 1 609.23008 115.6253)" class="B L">
                        <circle :fill="getPumpStatus(plc.dhwPumpAlarm, plc.dhwPumpStatus)" cx="218.782" cy="18.663" r="5.853" />
                        <path d="M216.519 24.114l7.917-4.086m-7.917-6.835l7.917 4.086" class="H" />
                     </g>
                     <g class="S">
                        <path d="M281.125 112.111v22.867h-2v-22.867z" />
                        <path d="M281.126 112.111h-10.955v-2h10.955z" fill-opacity=".699" />
                     </g>
                     <rect width="25.288" height="44.474" x="245.899" y="79.054" ry="4.31" fill="url(#B)" />
                     <text xml:space="preserve" x="258.019" y="103.852" font-size="7.056" class="F">
                        <tspan :visibility="getSectionStatus(plc.dhwStatus)" x="258.019" y="103.852" font-weight="bold" class="I J">
                           {{ t("components.climatix.dhwShort") }}
                        </tspan>
                     </text>
                     <rect width="25.288" height="44.474" x="245.899" y="24.526" ry="4.31" fill="url(#C)" />
                     <text xml:space="preserve" x="258.019" y="49.327" font-size="7.056" class="F">
                        <tspan :visibility="getSectionStatus(plc.ch1Status)" x="258.019" y="49.327" font-weight="bold" class="I J">
                           {{ t("components.climatix.ch1Short") }}
                        </tspan>
                     </text>
                     <text xml:space="preserve" x="115.4" y="20.126" class="F I K">
                        <tspan x="115.4" y="20.126">{{ plc.chHighInletPresure.toFixed(1) }} Bar</tspan>
                     </text>
                     <text xml:space="preserve" x="115.119" y="47.034" class="F I K">
                        <tspan x="115.119" y="47.034">{{ plc.chHighOutletPresure.toFixed(1) }} Bar</tspan>
                     </text>
                     <text xml:space="preserve" style="white-space: pre" x="568.322" y="-47.114" class="F K P">
                        <tspan x="493.777" y="17.813">{{ plc.outsideTemp.toFixed(1) }} °C</tspan>
                     </text>
                     <path
                        d="M508.694 19.791c0 .355-.288.643-.643.643s-.643-.288-.643-.643.288-.643.643-.643.643.288.643.643zm2.379-3.601h1.576v-1.286h-1.576zm0-3.537v1.286h1.576v-1.286zm0 5.788h1.576v-1.286h-1.576zm-.965-.731c.548.559.868 1.317.868 2.082 0 1.631-1.327 2.958-2.958 2.958s-2.958-1.327-2.958-2.958c0-.764.319-1.521.866-2.079l.002-3.934c0-1.152.938-2.09 2.09-2.09s2.09.938 2.09 2.09zm-.418 2.082c0-.489-.237-.977-.635-1.305l-.234-.193v-4.515c0-.443-.361-.804-.804-.804s-.804.361-.804.804l-.002 4.517-.233.193c-.396.328-.633.815-.633 1.303 0 .922.75 1.672 1.672 1.672s1.672-.75 1.672-1.672zm-5.949 1.672h-4.019c-.355 0-.643-.289-.643-.643v-7.926l2.669-2.435 2.669-2.435 2.606 2.377h1.908l-4.514-4.118-8.24 7.517.867.95.749-.683v6.752a1.93 1.93 0 0 0 1.929 1.929h5.255a4.26 4.26 0 0 1-.86-1.286z"
                        fill="url(#D)"
                     />
                  </g>
               </svg>
            </template>
         </Card>
      </div>
   </div>
</template>
