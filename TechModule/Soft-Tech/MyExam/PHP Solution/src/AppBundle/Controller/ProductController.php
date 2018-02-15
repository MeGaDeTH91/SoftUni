<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Product;
use AppBundle\Form\ProductType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class ProductController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
        $productRepository = $this->getDoctrine()->getRepository(Product::class); // Взимаме от базата
        $products = $productRepository->findAll(); // Намира всички Филми
        return $this->render(
            ':product:index.html.twig',
            ["products" => $products]);
	}

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        $product = new Product();
        $form = $this->createForm(ProductType::class, $product);

        $form->handleRequest($request);
        if($form->isSubmitted() && $form->isValid()){
            if($product->getName() == null || $product->getPriority() == null
                || $product->getStatus() == null || $product->getQuantity() == null){
                return $this->redirectToRoute('create');
            }

            $em = $this->getDoctrine()->getManager(); //Дай ми Entity Manager-а, той знае как се пише, трие в базата и т.н
            $em->persist($product); // Вземи от паметта и го натикай в базата данни - създай нова задача с тези данни
            $em->flush(); // save в базата

            return $this->redirectToRoute('index');
        }
        return $this->render(':product:create.html.twig',
            ["product" => $product, "form" => $form->createView()]);
	}

    /**
     * @Route("/edit/{id}", name="edit")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function edit($id, Request $request)
    {
        $productRepository = $this->getDoctrine()->getRepository(Product::class); // Взима от базата

        $product = $productRepository->find($id); // Намира Task по ID


        $form = $this->createForm(ProductType::class, $product); // Създаваме форма за това и я записваме в $task

        $form->handleRequest($request); // обработваме заявката

        if($form->isSubmitted() && $form->isValid()){

            if($product->getName() == null || $product->getPriority() == null
                || $product->getStatus() == null || $product->getQuantity() == null){
                return $this->render(':product:edit.html.twig',
                    ['product' => $product, 'form' => $form->createView()]); // Подаваме Film и Form в инициативен масив
            }

            $em = $this->getDoctrine()->getManager(); // Ползваме Entity Manager за да записваме, трием и т.н

            $em->merge($product); // merge == SaveOrUpdate в C#, обновява конкретния Task в базата
            $em->flush(); // Запазваме Промените

            return $this->redirectToRoute('index');
        }

        return $this->render(':product:edit.html.twig',
            ['product' => $product, 'form' => $form->createView()]); // Подаваме Film и Form в инициативен масив
    }
}
