﻿using FastTechFoods.Customer.Application.Common;
using FastTechFoods.Customer.Application.ExtensionMethods;
using FastTechFoods.Customer.Application.Interfaces.Repository;
using FastTechFoods.Customer.Application.Interfaces.Services;
using FastTechFoods.Customer.Application.ViewModel.MenuItem;
using FastTechFoods.Customer.Domain.Entities;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace FastTechFoods.Customer.Application.Services;
public class MenuItemService(ISendEndpointProvider sendEndpointProvider, IConfiguration config, IMenuItemRepository menuItemRepository) : IMenuItemService
{
    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;
    private readonly IConfiguration _configuration = config;
    private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;

    public async Task CreateMenuItemAsync(CreateMenuItemViewModel createMenuItemViewModel)
    {
        // Inserir na base de dados. 
        await _menuItemRepository.InsertAsync(createMenuItemViewModel.ToModel());

        // Se gravou com sucesso, colocar a mensagem da fila do rabbitmq.
        await RabbitMqHelper.SendMessageAsync(_sendEndpointProvider, _configuration, createMenuItemViewModel, "MassTransit_CreateItemMenu:NomeFila");
    }

    public async Task<bool> ExistsAsync(Guid id)
        => await _menuItemRepository.ExistsAsync(id);

    public async Task UpdateMenuItemAsync(UpdateMenuItemViewModel updateMenuItemViewModel)
    {
        var menuItem = await SetData(updateMenuItemViewModel);

        // Update na base de dados. 
        await _menuItemRepository.UpdateAsync(menuItem);

        // Se gravou com sucesso, colocar a mensagem da fila do rabbitmq.
        await RabbitMqHelper.SendMessageAsync(_sendEndpointProvider, _configuration, updateMenuItemViewModel, "MassTransit_UpdateItemMenu:NomeFila");
    }

    private async Task<MenuItem> SetData(UpdateMenuItemViewModel updateMenuItemViewModel)
    {
        var existingMenuItem = await _menuItemRepository.GetByIdAsync(updateMenuItemViewModel.Id);

        if (existingMenuItem is null)
            throw new Exception("Menu item not found.");

        existingMenuItem.UpdateFrom(updateMenuItemViewModel);

        return existingMenuItem;
    }
}
