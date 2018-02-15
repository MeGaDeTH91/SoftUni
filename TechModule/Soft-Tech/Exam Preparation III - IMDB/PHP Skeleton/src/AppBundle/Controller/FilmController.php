<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Film;
use AppBundle\Form\FilmType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpFoundation\Response;

class FilmController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return Response
     */
    public function index(Request $request)
    {
        $taskRepository = $this->getDoctrine()->getRepository(Film::class); // Взимаме от базата
        $films = $taskRepository->findAll(); // Намира всички Филми
        return $this->render(
            ':film:index.html.twig',
            ["films" => $films]);
    }

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return Response
     */
    public function create(Request $request)
    {
        $film = new Film();
        $form = $this->createForm(FilmType::class, $film);

        $form->handleRequest($request);
        if($form->isSubmitted() && $form->isValid()){
            if($film->getName() == null || $film->getGenre() == null
                || $film->getDirector() == null  || $film->getYear() == null){
                return $this->redirectToRoute('create');
            }

            $em = $this->getDoctrine()->getManager(); //Дай ми Entity Manager-а, той знае как се пише, трие в базата и т.н
            $em->persist($film); // Вземи от паметта и го натикай в базата данни - създай нова задача с тези данни
            $em->flush(); // save в базата

            return $this->redirectToRoute('index');
        }
        return $this->render(':film:create.html.twig',
            ["film" => $film, "form" => $form->createView()]);
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
        $filmRepository = $this->getDoctrine()->getRepository(Film::class); // Взима от базата

        $film = $filmRepository->find($id); // Намира Task по ID


        $form = $this->createForm(FilmType::class, $film); // Създаваме форма за това и я записваме в $task

        $form->handleRequest($request); // обработваме заявката

        if($form->isSubmitted() && $form->isValid()){

            if($film->getName() == null || $film->getGenre() == null
                || $film->getDirector() == null || $film->getYear() == null){
                return $this->render(':film:edit.html.twig',
                    ['film' => $film, 'form' => $form->createView()]); // Подаваме Film и Form в инициативен масив
            }

            $em = $this->getDoctrine()->getManager(); // Ползваме Entity Manager за да записваме, трием и т.н

            $em->merge($film); // merge == SaveOrUpdate в C#, обновява конкретния Task в базата
            $em->flush(); // Запазваме Промените

            return $this->redirectToRoute('index');
        }

        return $this->render(':film:edit.html.twig',
            ['film' => $film, 'form' => $form->createView()]); // Подаваме Film и Form в инициативен масив
    }

    /**
     * @Route("/delete/{id}", name="delete")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function delete($id, Request $request)
    {
        $filmRepository = $this->getDoctrine()->getRepository(Film::class); // Взима от базата

        $film = $filmRepository->find($id); // Намира Task по ID

        $form = $this->createForm(FilmType::class, $film); // Създаваме форма за това и я записваме в $task

        $form->handleRequest($request); // обработваме заявката

        if($form->isSubmitted() && $form->isValid()){

            $em = $this->getDoctrine()->getManager(); // Ползваме Entity Manager за да записваме, трием и т.н

            $em->remove($film); // Трием конкретния film, ползваме $em->persist($film) и за Edit
            $em->flush();

            return $this->redirectToRoute('index');
        }

        return $this->render(':film:delete.html.twig',
            ['film' => $film, 'form' => $form->createView()]); // Подаваме Task и Form в инициативен масив
    }
}
