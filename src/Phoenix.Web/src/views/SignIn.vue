<script setup lang="ts">
import { Ref, ref } from 'vue';
import { useI18n } from 'vue-i18n';
import { ClickEvent } from 'devextreme/ui/button';
import { getUserTokenAsync } from '../api/userApi';
import { displayError } from '../helpers/toastHelper';
import { GetUserTokenQuery } from '../models/api/users/queries/getUserTokenQuery';

const { t } = useI18n();

const isLoading: Ref<boolean> = ref(false);
const toastIsVisible: Ref<boolean> = ref(false);
const request: Ref<GetUserTokenQuery> = ref({
   email: '',
   password: '',
});

async function userLoginClickAsync(e: ClickEvent): Promise<void> {
   try {
      isLoading.value = true;

      if (e.validationGroup?.validate()?.isValid != true) {
         return;
      }

      await getUserTokenAsync(request.value);
   } catch (error) {
      displayError(
         error,
         () => {
            toastIsVisible.value = true;
         },
         () => {
            toastIsVisible.value = false;
         }
      );
   } finally {
      isLoading.value = false;
   }
}
</script>

<template>
   <LoadPanel :visible="isLoading" />
   <div class="mx-auto py-5 card-login">
      <Card :show-header="false">
         <template #body>
            <div class="row pb-2">
               <div class="col text-center">
                  <i class="dx-icon-user card-icon" />
               </div>
            </div>
            <div class="row px-2 pt-2">
               <div class="col-12">
                  <DxValidationGroup>
                     <div class="dx-field">
                        <DxTextBox :disabled="isLoading || toastIsVisible" :placeholder="t('views.signIn.email.placeHolder')" v-model="request.email" width="100%">
                           <DxValidator>
                              <DxEmailRule :ignore-empty-value="false" :message="t('views.signIn.email.emailValidator')" />
                              <DxStringLengthRule :ignore-empty-value="false" :max="50" :message="t('views.signIn.email.lengthValidator')" />
                           </DxValidator>
                        </DxTextBox>
                     </div>
                     <div class="dx-field pt-2">
                        <DxTextBox :disabled="isLoading || toastIsVisible" :placeholder="t('views.signIn.password.placeHolder')" mode="password" v-model="request.password" width="100%">
                           <DxValidator>
                              <DxStringLengthRule :ignore-empty-value="false" :min="10" :max="30" :message="t('views.signIn.password.lengthValidator')" />
                           </DxValidator>
                        </DxTextBox>
                     </div>
                     <div class="dx-field py-2">
                        <DxButton
                           :disabled="isLoading || toastIsVisible"
                           :text="t('views.signIn.loginButton')"
                           height="45px"
                           icon="check"
                           type="default"
                           styling-mode="outfilled"
                           width="100%"
                           @click="userLoginClickAsync"
                        />
                     </div>
                  </DxValidationGroup>
               </div>
            </div>
         </template>
      </Card>
   </div>
</template>
