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
                     <text x="199.94214" y="94.78157" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan>{{ plc.dhwValvePosition.toFixed(1) }} %</tspan></text>
                     <text x="200.04912" y="42.26754" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="200.04912" y="42.26754">{{ plc.ch1ValvePosition.toFixed(1) }} %</tspan></text>
                     <g transform="translate(-.382 -2.12)">
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
                     <text x="297.73947" y="74.870934" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="297.73947" y="74.870934">{{ plc.dhwTemp.toFixed(1) }} °C</tspan></text>
                     <text x="297.73947" y="67.756256" style="fill:#ff0000;font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="297.73947" y="67.756256">{{ plc.dhwTempSet.toFixed(1) }} °C</tspan></text>
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
                     <text x="20.041454" y="45.917336" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="20.041454" y="45.917336" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265">p{{ $t('components.climatix.network') }}</tspan></text>
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
                     <text x="513.12549" y="47.578751" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="513.12549" y="47.578751" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">p{{ $t('components.climatix.ch') }}</tspan></text>
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
                     <g transform="matrix(.17 0 0 .171 467 77.8)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <rect x="270" y="85.9" width="237" height="2" style="fill:#f1b345;stroke-width:.369"/>
                     <g transform="matrix(.17 0 0 .171 467 102)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <g transform="matrix(1.01 0 0 1.01 348 92.3)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.5 0 0 1.49 310 -14.6)" style="stroke-width:.779">
                        <rect x="69.1" y="74.5" width="5.35" height="8.2" ry="1.56" style="fill:none;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.362;stroke:#000"/>
                        <path d="m69.1 78.6 5.31-.1" style="fill:none;stroke-width:.284;stroke:#000"/>
                        <rect x="71.2" y="82.8" width="1.17" height=".797" ry="0" style="fill:none;paint-order:markers stroke fill;stroke-linejoin:round;stroke-width:.206;stroke:#000"/>
                     </g>
                     <rect x="270" y="110" width="236" height="2" style="fill:#00da31;stroke-width:.369"/>
                     <path d="m505 85.1v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <path d="m505 109v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <g transform="matrix(1.01 0 0 1.01 280 92.3)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <text x="513.33771" y="75.58313" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="513.33771" y="75.58313" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">p{{ $t('components.climatix.waterWarm') }}</tspan></text>
                     <text x="513.33771" y="99.83136" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="513.33771" y="99.83136" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">p{{ $t('components.climatix.waterCold') }}</tspan></text>
                     <g transform="matrix(1.01 0 0 1.01 348 115)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(1.01 0 0 1.01 400 115)" style="stroke-width:.989">
                        <path d="m17.5 17.7v-3.02" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m17.5 14.7a2.38 2.42 0 01-2.38-2.42 2.38 2.42 0 012.38-2.42 2.38 2.42 0 012.38 2.42 2.38 2.42 0 01-2.38 2.42" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279;stroke:#000"/>
                        <path d="m16.2 11.1 2.38 2.42" style="fill:none;stroke-width:.279px;stroke:#000"/>
                        <path d="m16.2 11.1.626 1.11.453-.451z" style="fill-rule:evenodd;stroke-linecap:round;stroke-linejoin:round;stroke-width:.279px;stroke:#000"/>
                     </g>
                     <g transform="matrix(.17 0 0 .171 467 125)" style="stroke-width:1.66">
                        <path d="m17.7 49.6v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="translate(-138 10.6)" d="m156 21.3a14.2 14.2 0 01-14.2-14.2 14.2 14.2 0 0114.2-14.2 14.2 14.2 0 0114.2 14.2 14.2 14.2 0 01-14.2 14.2" style="fill:none;stroke-linecap:round;stroke-linejoin:round;stroke-width:1.66;stroke:#000"/>
                        <path d="m17.7 24.8v-17.7" style="fill:none;stroke-width:1.66px;stroke:#000"/>
                        <path transform="matrix(1.5 0 0 1.5 -6.2 -9.74)" d="m15.9 24.8a1.77 1.77 0 01-1.77-1.77 1.77 1.77 0 011.77-1.77 1.77 1.77 0 011.77 1.77 1.77 1.77 0 01-1.77 1.77"/>
                     </g>
                     <rect x="279" y="133" width="228" height="2" style="fill:#f1b345;stroke-width:.373"/>
                     <path d="m505 132v3.52l8.2-3.52v3.52z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.298"/>
                     <text x="513.33771" y="122.99466" style="font-family:sans-serif;font-size:5.64px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="513.33771" y="122.99466" style="font-family:sans-serif;font-size:5.64px;stroke-width:.265;text-align:end;text-anchor:end">p{{ $t('components.climatix.circulation') }}</tspan></text>
                     <g transform="matrix(1.13 0 0 .986 224 79.3)" style="stroke-width:1.07">
                        <rect x="86.7" y="53.7" width="7.28" height="3.57" style="fill:#fff;paint-order:markers stroke fill"/>
                        <path d="m86.7 53.7v3.57l7.28-3.57v3.57z" fill="none" stroke="#000" style="fill:#fff;stroke-width:.283"/>
                     </g>
                     <g transform="matrix(-1 0 0 1 609 116)" :fill="getPumpStatus(plc.dhwPumpAlarm, plc.dhwPumpStatus)">
                        <ellipse cx="219" cy="18.7" rx="5.85" ry="5.85" style="stroke-width:.3;stroke:#000"/>
                        <path d="m217 24.1 7.92-4.09" style="fill-rule:evenodd;stroke-width:.3;stroke:#000"/>
                        <path d="m217 13.2 7.92 4.09" style="fill-rule:evenodd;stroke-width:.3;stroke:#000"/>
                     </g>
                     <rect transform="rotate(90)" x="112" y="-281" width="22.9" height="2" style="fill:#f1b345;stroke-width:.306"/>
                     <rect transform="scale(-1)" x="-281" y="-112" width="11" height="2" style="fill-opacity:.699;fill:#f1b345;stroke-width:.313"/>
                     <rect x="246" y="79.1" width="25.3" height="44.5" ry="4.31" style="fill:url(#c);stroke-width:.266"/>
                     <text x="258.01889" y="103.85228" style="font-family:sans-serif;font-size:7.06px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="258.01889" y="103.85228" style="fill:#ffffff;font-family:sans-serif;font-size:7.06px;font-weight:bold;stroke-width:.265;text-align:center;text-anchor:middle" :visibility="getSectionStatus(plc.dhwStatus)">{{ t('components.climatix.dhwShort') }}</tspan></text>
                     <rect x="246" y="24.5" width="25.3" height="44.5" ry="4.31" style="fill:url(#e);stroke-width:.266"/>
                     <text x="258.54254" y="48.733189" style="font-family:sans-serif;font-size:7.06px;line-height:1.25;stroke-width:.265" xml:space="preserve"><tspan x="258.54254" y="48.733189" style="fill:#ffffff;font-family:sans-serif;font-size:7.06px;font-weight:bold;stroke-width:.265;text-align:center;text-anchor:middle" :visibility="getSectionStatus(plc.ch1Status)">{{ t('components.climatix.ch1Short') }}</tspan></text>
                     <text x="115.39965" y="20.126001" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="115.39965" y="20.126001">{{ plc.chHighInletPresure.toFixed(1) }} Bar</tspan></text>
                     <text x="115.11905" y="47.033669" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;line-height:1.25;stroke-width:.265;text-align:center;text-anchor:middle" xml:space="preserve"><tspan x="115.11905" y="47.033669">{{ plc.chHighOutletPresure.toFixed(1) }} Bar</tspan></text>
                     <text transform="translate(-74.5 64.9)" x="568.32159" y="-47.113564" style="font-family:sans-serif;font-size:6.35px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;inline-size:133.935;line-height:1.25;stroke-width:.265;text-align:end;text-anchor:end;white-space:pre" xml:space="preserve"><tspan x="568.32159" y="-47.113564">{{ plc.outsideTemp.toFixed(1) }} °C</tspan></text>
                     <path d="m509 19.8c0 .355-.288.643-.643.643-.355 0-.643-.288-.643-.643 0-.355.288-.643.643-.643.355 0 .643.288.643.643zm2.38-3.6h1.58v-1.29h-1.58zm0-3.54v1.29h1.58v-1.29zm0 5.79h1.58v-1.29h-1.58zm-.965-.731c.548.559.868 1.32.868 2.08 0 1.63-1.33 2.96-2.96 2.96s-2.96-1.33-2.96-2.96c0-.764.319-1.52.866-2.08l.002-3.93c0-1.15.938-2.09 2.09-2.09 1.15 0 2.09.938 2.09 2.09zm-.418 2.08c0-.489-.237-.977-.635-1.3l-.234-.193v-4.52c0-.443-.361-.804-.804-.804-.443 0-.804.361-.804.804l-.002 4.52-.233.193c-.396.328-.633.815-.633 1.3 0 .922.75 1.67 1.67 1.67.922 0 1.67-.75 1.67-1.67zm-5.95 1.67h-4.02c-.355 0-.643-.289-.643-.643v-7.93l5.34-4.87 2.61 2.38h1.91l-4.51-4.12-8.24 7.52.867.95.749-.683v6.75c0 1.06.865 1.93 1.93 1.93h5.26c-.36-.37-.653-.805-.86-1.29z" fill="url(#a)" style="fill:url(#d);stroke-width:.0549"/>
                  </g>
               </svg>
            </template>
         </Card>
      </div>
   </div>
</template>
