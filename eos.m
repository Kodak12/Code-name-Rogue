function eos( Pressure, Temperature, mass )
% Uses different equation of states to calculate volumetric flow rate given
% temperature, pressure and molar flow rate
%  
%INITIALIZE VARIABLES
    P = Pressure; % atm
    T = Temperature; % K
    m = mass; % kg/s
    L = 950; % ft
    D = 12; % inch
    f = 0.0003; % Given constant
    R = 0.08206; % atm*l/mol*k
    Mw = 64.07; % kg/kmol
    
    % mole calculation for SO2
        n = (m/Mw)*1000; % mol/s
        
    % Converts length and diameter to meters
        L = L/3.2808; % Length in (m)
        D = D/39.37; % Diameter in (m)
    
    % Calculates area
        A = pi*((D^2)/4) % Cross-sectional area in (m^2)
        
    function idealGas()
        %Computes volumtric flow rate and molar volume using the ideal gas EOS
            
            Vflow_I = (n*R.*T)./P; % Volumeric flow rate in (L/s)
            
            Vhat_I = Vflow_I./n; % Molar Volume in (L/mol)
            
            velocity_I = (Vflow_I/1000)./A; % Velocity of gas in (m/s)
            
            density_I = m./Vflow_I; % Density of gas (kg/L) equivalent to (gm/cc)
            
            uLoss_I = 4*f*(L/D)*0.5*(density_I*1000).*velocity_I.^2; % Loss estimate in (Pa*m)
          
            idealTable = [Vhat_I; Vflow_I; velocity_I; density_I; uLoss_I];
            
            Table = array2table(idealTable', 'variablenames',{'Vhat_I', 'Vflow_I', 'velocity_I', ...
                'density_I', 'uLoss_I'})
    end

    function virialTrunc()
        % Computes molar volume using virial truncated EOS
        
            w = 0.251; % pitzer acentric factor for SO2
            Tc = 430.7; % critical temperature (K)
            Pc = 77.8; % critical pressusre (atm)

            Pr = P / Pc % Reduced pressure
            Tr = T / Tc % Reduced temperature

            Bo = 0.083 - (0.422 ./ (Tr.^1.6)); % calculates Bo for estimation of B
            B1 = 0.139 - (0.172 ./ (Tr.^4.2)); % calculates B1 for estimation of B

            B = ((R * Tc) / Pc) * (Bo + w * B1); % Calculates virial 2body constant

            Vhat_V = (1 + (B * P / (R * T))) * ((R * T) / P); % molar volume(L/mol)
                
            Vflow_V = Vhat_V*n; % Volumetric flow rate in (L/s)
            
            velocity_V = (Vflow_V/1000)/A; % velocity in (m/s)
            
            density_V = m./Vflow_V; % Density in (kg/L) equivalent to (gm/cc)
            
            uLoss_V = 4*f*(L/D)*.5*(density_V*1000).*velocity_V.^2; % Loss estimate in (Pa*m)
            
            VirialTable = [Vhat_V; Vflow_V; velocity_V; density_V; uLoss_V];
            Table = array2table(VirialTable', 'variablenames',{'Vhat_V', 'Vflow_V', 'velocity_V', ...
                'density_V', 'uLoss_V'})
    end
         
     idealGas
     virialTrunc         
                 


end

