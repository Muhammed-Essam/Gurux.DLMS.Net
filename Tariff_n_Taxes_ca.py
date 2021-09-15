class StepTariffOne:
    def __init__(self):
        self.StepOne = [0, 50, 0.38, False, 0, True, 0.20]
        self.StepTwo = [51, 100, 0.48, False, 0, True, 0.40]
        self.StepThree = [101, 200, 0.65, True, 22.65, True, 0.60]
        self.StepFour = [201, 350, 0.96, False, 0, True, 0.80]
        self.StepFive = [351, 650, 1.18, False, 0, True, 1.00]
        self.StepSix = [651, 1000, 1.40, True, 282, True, 1.20]
        self.StepSeven = [1001, 10000, 2.00, True, 600, True, 1.40]

    def per_kwh_cost(self, current_power_consumption, radio_tax_value, consumption_tax_value):
        return self.cost_calculator_kwh(current_power_consumption) + \
                  self.radio_tax(current_power_consumption, radio_tax_value) + \
                  self.consumption_tax(current_power_consumption, consumption_tax_value)

    def consumption_tax(self, current_power_consumption, tax_value):
        if current_power_consumption % 2 == 0:
            return tax_value
        else:
            return 0

    def radio_tax(self, current_power_consumption, tax_value):
        if current_power_consumption <= 8:
            return tax_value
        else:
            return 0

    def cost_calculator_kwh(self, current_power_consumption):
        if current_power_consumption < self.StepTwo[0]:
            if self.StepOne[3]:
                self.StepOne[3] = False
                if self.StepOne[5]:
                    self.StepOne[5] = False
                    return self.StepOne[2] + self.StepOne[4] + self.StepOne[6]
                else:
                    return self.StepOne[2] + self.StepOne[4]
            else:
                if self.StepOne[5]:
                    self.StepOne[5] = False
                    return self.StepOne[2] + self.StepOne[6]
                else:
                    return self.StepOne[2]
        elif current_power_consumption < self.StepThree[0]:
            if self.StepTwo[3]:
                self.StepTwo[3] = False
                if self.StepTwo[5]:
                    self.StepTwo[5] = False
                    return self.StepTwo[2] + self.StepTwo[4] + self.StepTwo[6]
                else:
                    return self.StepTwo[2] + self.StepTwo[4]
            else:
                if self.StepTwo[5]:
                    self.StepTwo[5] = False
                    return self.StepTwo[2] + self.StepTwo[6]
                else:
                    return self.StepTwo[2]

        elif current_power_consumption < self.StepFour[0]:
            if self.StepThree[3]:
                self.StepThree[3] = False
                if self.StepThree[5]:
                    self.StepThree[5] = False
                    return self.StepThree[2] + self.StepThree[4] + self.StepThree[6]
                else:
                    return self.StepThree[2] + self.StepThree[4]
            else:
                if self.StepThree[5]:
                    self.StepThree[5] = False
                    return self.StepThree[2] + self.StepThree[6]
                else:
                    return self.StepThree[2]

        if current_power_consumption < self.StepFive[0]:
            if self.StepFour[3]:
                self.StepFour[3] = False
                if self.StepFour[5]:
                    self.StepFour[5] = False
                    return self.StepFour[2] + self.StepFour[4] + self.StepFour[6]
                else:
                    return self.StepFour[2] + self.StepFour[4]
            else:
                if self.StepFour[5]:
                    self.StepFour[5] = False
                    return self.StepFour[2] + self.StepFour[6]
                else:
                    return self.StepFour[2]
            
        if current_power_consumption < self.StepSix[0]:
            if self.StepFive[3]:
                self.StepFive[3] = False
                if self.StepFive[5]:
                    self.StepFive[5] = False
                    return self.StepFive[2] + self.StepFive[4] + self.StepFive[6]
                else:
                    return self.StepFive[2] + self.StepFive[4]
            else:
                if self.StepFive[5]:
                    self.StepFive[5] = False
                    return self.StepFive[2] + self.StepFive[6]
                else:
                    return self.StepFive[2]

        if current_power_consumption < self.StepSeven[0]:
            if self.StepSix[3]:
                self.StepSix[3] = False
                if self.StepSix[5]:
                    self.StepSix[5] = False
                    return self.StepSix[2] + self.StepSix[4] + self.StepSix[6]
                else:
                    return self.StepSix[2] + self.StepSix[4]
            else:
                if self.StepSix[5]:
                    self.StepSix[5] = False
                    return self.StepSix[2] + self.StepSix[6]
                else:
                    return self.StepSix[2]

        else:
            if self.StepSeven[3]:
                self.StepSeven[3] = False
                if self.StepSeven[5]:
                    self.StepSeven[5] = False
                    return self.StepSeven[2] + self.StepSeven[4] + self.StepSeven[6]
                else:
                    return self.StepSeven[2] + self.StepSeven[4]
            else:
                if self.StepSeven[5]:
                    self.StepSeven[5] = False
                    return self.StepSeven[2] + self.StepSeven[6]
                else:
                    return self.StepSeven[2]
